
# Shad Event Service API Documentation

## Introduction

The Shad Event Service is designed and implemented to facilitate the management and participation of users in events related to cultural, social, and educational activities. This service enables the redirection of Shad users to the event platform without the need for repeated authentication, ensuring a seamless experience for participants.

To use this service, the event organizer must obtain the required permissions and configure the event settings in the Shad system. Once configured, the event can be displayed in the Shad application, allowing users to access the event through a specified link.


## Event Configuration

To configure an event, the following information is required:

### Event ID, Username, and Password
- This information is needed for event organizers to authenticate users. The details will be provided by the Shad operations team.

### Connection Link
- The event organizer needs to provide a redirection link to guide Shad users to the event’s specific page.
- The link should be structured as a **QueryString** parameter using the `UserID` value as follows:

#### Example:
```bash
https://mysite.ir/shad?UserID=D4-76-29-46-BA-E1-88-74-C1-51-89-2A-D1-A8-58-C0
```
In this example, the `UserID` parameter is the identifier of the user in Shad.


## Methods

### `Login` Method

This method is used to authenticate the event organizer and retrieve a token for further interactions.

- **URL**
  ```bash
  https://shadapi.noyanet.com/api/v1/Account/login
  ```

- **Input Parameters**

  | **Parameter** | **Type**  | **Mandatory** | **Description**                          |
  |---------------|-----------|---------------|------------------------------------------|
  | `landingId`   | `int`     | Yes           | Unique identifier for the event.         |
  | `username`    | `string`  | Yes           | The username provided for the event.     |
  | `password`    | `string`  | Yes           | The password provided for the event.     |

- **Example Request**

  ```bash
  curl -X 'POST' \
  'https://shadapi.noyanet.com/api/v1/Account/login' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
    "landingId": [your landingId],
    "username": "[your username]",
    "password": "[your password]"
  }'
  ```

- **Response Example**

  ```json
  {
    "data": "[Token]",
    "success": true,
    "statusCode": "OK",
    "code": 200,
    "description": "با موفقیت انجام شد"
  }
  ```

## `ShadEvent` Method

This method is used to retrieve the user's information after successful authentication.

- **URL**:
  ```
  https://shadapi.noyanet.com/api/v1/ShadEvent?UserHashId=[your userId]
  ```

- **Input Parameters**:

  | **Parameter** | **Type**  | **Mandatory** | **Description**                          |
  |---------------|-----------|---------------|------------------------------------------|
  | `Token`       | `string`  | Yes           | The token received from the `Login` method in the header. |
  | `UserHashId`  | `string`  | Yes           | The unique identifier of the user.       |

- **Example Request**:

  ```bash
  curl -X 'GET' \
  'https://shadapi.noyanet.com/api/v1/ShadEvent?UserHashId=[your userId]' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer [token]'
  ```

- **Response Example** for an authenticated user:

  ```json
  {
    "data": {
      "id": 516222,
      "nationalId": null,
      "hashedId": "C3-A4-F5-C2-27-14-D9-56-A6-A0-AE-90-3A-E0-CF-2E",
      "name": "رونيكا",
      "family": "نادم كچائي",
      "event": null,
      "provinceName": "گیلان",
      "mobile": "989226670378",
      "courseStudy": "دوره ابتدایی توصیفی",
      "districtName": "1رشت .ناحیه",
      "fundamentalId": 3,
      "role": "student"
    },
    "success": true,
    "statusCode": 200,
    "code": 200,
    "description": "با موفقیت انجام شد"
  }
  ```

- **Response Example** for an unauthenticated user:

  ```json
  {
    "data": {
      "id": 516223,
      "nationalId": null,
      "hashedId": "E7-17-70-D6-D0-37-26-FE-4F-74-A7-ED-89-23-46-FC",
      "name": null,
      "family": null,
      "event": null,
      "provinceName": null,
      "mobile": "989388332389",
      "courseStudy": null,
      "districtName": null,
      "fundamentalId": null,
      "role": null
    },
    "success": true,
    "statusCode": 200,
    "code": 200,
    "description": "با موفقیت انجام شد"
  }
  ```

---

## Event Workflow

The following steps outline the event workflow for a Shad user:

1. **User clicks on the event link** in the Shad application.
2. The user is redirected to the specified **connection link** (`UserID` is passed as a parameter).
3. The event organizer authenticates using the `Login` method and retrieves a **token**.
4. The organizer uses the `ShadEvent` method with the token and `UserID` to **fetch user information** and update the event platform.

---
**Version**: 2024, September   
**Publisher**: ShadNoyan Network Technology Company
