<!-- <style>
aside.VPSidebar, header.VPNav {
  display: '';
}
</style> -->
# Shad Payment Gateway API Documentation

## Introduction
The Shad Payment Gateway API is designed and implemented to facilitate payment services for users interacting with the Shad application. This API aims to streamline payment processes and provide easy integration for external applications.


## Configuration

1. **API Key**
   - Each service provider is assigned a unique API key by the technical department.
   
2. **Event ID**
   - The event ID is also provided to the service provider for tracking purposes.


## Methods

### `SendRequest` Method

This method is used to send a payment request through the Shad payment gateway.

- **URL**  
  ```
  https://shadpaymentgateway.shadnoyan.com/api/v1/Payment/SendRequest
  ```

- **Input Parameters**:
  
  | **Parameter**       | **Type**     | **Mandatory** | **Description**                                      |
  |---------------------|--------------|---------------|------------------------------------------------------|
  | `apiKey`            | `string`     | Yes           | The API key to be included in the request header.     |
  | `eventId`           | `int`        | Optional      | The event ID for the payment transaction.             |
  | `userId`            | `string`     | Yes           | The unique identifier of the user.                    |
  | `amount`            | `int`        | Yes           | The amount of the payment in Rials.                   |
  | `orderId`           | `string`     | Yes           | The unique order ID.                                  |
  | `additionalData`    | `string`     | Optional      | Additional information for the transaction.           |
  | `postCallBackUrl`   | `string`     | Yes           | URL to receive the payment status update.             |
  | `getRedirectUrl`    | `string`     | Yes           | URL to redirect the user after payment completion.    |

- **Example Request**
  
  ```bash
  curl -X 'POST' \
  'https://shadpaymentgateway.shadnoyan.com/api/v1/Payment/SendRequest' \
  -H 'accept: text/plain' \
  -H 'apiKey: [Your apiKey]' \
  -H 'Content-Type: application/json' \
  -d '{
    "eventId": [Your EventId],
    "userId": [UserId],
    "amount": [Amount],
    "orderId": [OrderId],
    "additionalData": [AdditionalData],
    "postCallBackUrl": [PostCallBackUrl],
    "getRedirectUrl": [GetRedirectUrl]
  }'
  ```

- **Response Example**:

  ```json
  {
    "isSuccess": true,
    "statusCode": 200,
    "code": 200,
    "description": "با موفقیت انجام شد"
  }
  ```

---

### `Reverse` Method

This method is used to reverse a payment transaction in cases where the user has successfully made a payment, but the service or product cannot be provided.

- **URL**
  ```
  https://shadpaymentgateway.shadnoyan.com/api/v1/Payment/Reverse
  ```

- **Input Parameters**

  | **Parameter** | **Type**  | **Mandatory** | **Description**                                      |
  |---------------|-----------|---------------|------------------------------------------------------|
  | `apiKey`      | `string`  | Yes           | The API key to be included in the request header.     |
  | `orderId`     | `string`  | Yes           | The unique order ID of the transaction to be reversed. |

- **Example Request**

  ```bash
  curl -X 'POST' \
  'https://shadpaymentgateway.shadnoyan.com/api/v1/Payment/Reverse' \
  -H 'accept: text/plain' \
  -H 'apiKey: [Your apiKey]' \
  -H 'Content-Type: application/json' \
  -d '{
    "orderId": [OrderId]
  }'
  ```

- **Response Example**

  ```json
  {
    "isSuccess": true,
    "statusCode": 200,
    "code": 200,
    "description": "با موفقیت انجام شد"
  }
  ```

## Notes

- **Event ID** and **API Key** must be correctly configured to ensure successful transactions.
- Ensure that the `postCallBackUrl` and `getRedirectUrl` are accurately set up to receive transaction status and user redirection respectively.
- For the `Reverse` method, the request must be made within 30 minutes of the original payment.

## Additional Information
This API is managed by the ShadNoyan Network Technology Company and is intended for integration into the Shad educational platform. Ensure proper use of the API to maintain transaction integrity and provide a seamless payment experience for users.

**Version**: 2024, October   
**Publisher**: ShadNoyan Network Technology Company

--- 

This document provides an overview of the core functionalities and methods for integrating with the Shad Payment Gateway API. For detailed use cases and advanced configurations, please refer to the full technical guide.