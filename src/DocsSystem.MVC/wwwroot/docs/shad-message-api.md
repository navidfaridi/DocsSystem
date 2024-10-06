<!-- <style>
aside.VPSidebar, header.VPNav {
  display: '';
}
</style> -->

# Shad Send Message Service API Documentation

## Introduction

The Shad Send Message Service API is designed to facilitate sending messages to users of the Shad application. The API is intended for educational, cultural, and social communication between students, teachers, and managers. After obtaining the necessary permissions, the service can be used to send messages to registered users of the Shad application.

## Configuration

To use the service, the following configurations must be completed:

1. **Username and Password**:
   - Users will receive a username and password to log in to the Shad Hamyar platform at the URL:
   ```
   http://hamyar.shadnoyan.com/
   ```
   
2. **Service Key**:
   - Each user can generate an API key in their Shad Hamyar account to authorize message requests.
   - To create a key, navigate to the "Create Key" option and follow the prompts to generate a new key. 
   - Once created, the key can be copied and stored for use in the API requests.
   
3. **Service ID**:
   - The service ID is a unique identifier for each user's service in the Shad platform.

---

## Methods

### `SendMessages` Method

This method is used to send multiple messages to users via the Shad platform.

- **URL**:
  ```
  https://msg.shadnoyan.com/api/v1/Shad/SendMessages
  ```

- **Input Parameters**

  | **Parameter**       | **Type**     | **Mandatory** | **Description**                                      |
  |---------------------|--------------|---------------|------------------------------------------------------|
  | `apiKey`            | `string`     | Yes           | The API key provided in the Shad Hamyar platform.     |
  | `serviceId`         | `int`        | Yes           | The unique identifier of the service.                 |
  | `data`              | `array`      | Yes           | An array of messages and corresponding mobile numbers.|

- **Example Request**

  ```bash
  curl -X 'POST' \
  'https://msg.shadnoyan.com/api/v1/Shad/SendMessages' \
  -H 'accept: text/plain' \
  -H 'apiKey: [Your ApiKey]' \
  -H 'Content-Type: application/json' \
  -d '{
    "serviceId": [Your ServiceId],
    "data": [
      {
        "message": "[Message1]",
        "mobile": [Mobile1]
      },
      {
        "message": "[Message2]",
        "mobile": [Mobile2]
      }
    ]
  }'
  ```

- **Response Example**

  ```json
  {
    "data": [RequestId],
    "isSuccess": true,
    "statusCode": 200,
    "code": 200,
    "description": ""
  }
  ```

- **Parameter Descriptions**

  - `apiKey`: The API key obtained from the Shad Hamyar platform.
  - `serviceId`: The unique ID of the service.
  - `data`: An array containing the message text and corresponding mobile number for each recipient.


## Notes

1. Ensure that the `apiKey` and `serviceId` are correctly configured to avoid authentication issues.
2. The message data should be formatted as a JSON array containing the message text and recipient mobile number.

**Version**: 1403, Ramazan Month  
**Publisher**: ShadNoyan Network Technology Company
