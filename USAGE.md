[api_reference]: https://serversmtp.com/turbo-api/
[openapi_generator]: https://openapi-generator.tech/

This documentation is based on our [Open API Specification][api_reference]

# This SDK consists of 2 Core projects + 1 Testing Project.

## **API.TurboSMTP**

This project provides a wrapper for the turboSMTP API. It is automatically generated from our Open API Specification V3 using the [Open API Generator Client][openapi_generator]

## **turboSMTP**

This project offers a higher-level wrapper for **API.TurboSMTP**, simplifying usage by abstracting infrastructure details and the complexities of REST API connections.

## **turboSMTP.Test**

This project is intended for unit testing the TurboSMTP project. It includes a suite of tests to ensure the correctness, reliability, and performance of the TurboSMTP functionality. By providing comprehensive test coverage, it helps maintain the integrity of the SDK as new features are added or existing ones are modified.