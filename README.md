# Name Classification API

## Overview

This project exposes a single GET endpoint that classifies a given name by integrating with the Genderize API. It processes the raw response and returns a structured, enriched result with additional computed fields.

---

## What This API Does

* Accepts a `name` query parameter
* Calls the external Genderize API
* Extracts and transforms the response
* Applies business rules to determine confidence
* Returns a clean, structured JSON response

---

## Endpoint

### Classify Name

```
GET /api/classify?name={name}
```

---

## Success Response (200 OK)

```json
{
  "status": "success",
  "data": {
    "name": "john",
    "gender": "male",
    "probability": 0.99,
    "sample_size": 1234,
    "is_confident": true,
    "processed_at": "2026-04-01T12:00:00Z"
  }
}
```

---

## Processing Rules

* Extract the following fields from the external API:

  * `gender`
  * `probability`
  * `count` → renamed to `sample_size`

* Compute:

  * `is_confident`:

    * `true` if:

      * `probability >= 0.7`
      * AND `sample_size >= 100`
    * Otherwise `false`

* Generate:

  * `processed_at`

    * Must be dynamic (generated per request)
    * Format: UTC, ISO 8601 (e.g. `2026-04-01T12:00:00Z`)
    * Must NOT be hardcoded

---

## Error Handling

### General Error Format

```json
{
  "status": "error",
  "message": "<error message>"
}
```

### Possible Errors

#### 400 Bad Request

* Missing `name` parameter
* Empty `name` value

#### 422 Unprocessable Entity

* `name` is not a string

#### 500 / 502

* Server failure
* External API failure

---

## Genderize Edge Cases

If the external API returns:

* `gender: null`
* OR `count: 0`

Return:

```json
{
  "status": "error",
  "message": "No prediction available for the provided name"
}
```
## Example Request
GET /api/classify?name=anna

## Design Decisions

* **DTO-based response shaping**
  Ensures separation between external API schema and internal response format.

* **Explicit validation**
  Prevents invalid inputs early and returns meaningful error messages.

* **Derived fields (`is_confident`)**
  Adds business value beyond raw API data.

* **Timestamp generation (`processed_at`)**
  Ensures traceability and freshness of responses.

---

