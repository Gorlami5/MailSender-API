# MailSender-API

This project is intended as a reference for developers who want to manage email-sending requirements through an API.
The primary goal is to abstract SMTP protocol integration, separate responsibilities using a layered architecture, and provide a foundational API example suitable for real-world usage scenarios.

## Why is the repository matter?

- In modern applications, email sending is a requirement in almost every backend service:

- User verification emails

- Password reset emails

- Notifications

- Newsletters

However, email delivery must be handled carefully in terms of security, performance, and configuration.
This API aims to demonstrate how these requirements can be addressed using a clean architecture and real-world application examples.

## Features and Contents

Main topics covered in this project include:
- Secure email sending with SMTP configuration
- Domain and infrastructure separation using Onion (layered) architecture
- RESTful API endpoints
- Dependency abstraction and extensible design
- Sample configuration and usage examples


## Target Audience

This repository is suitable for:
- Backend developers
- Developers building APIs with .NET
- Those who need to send emails using SMTP
- Developers who want to explore or reference the Onion / Clean Architecture approach

## How is work?

- git clone https://github.com/Gorlami5/MailSender-API.git
- cd MailSender-API
- dotnet restore
- dotnet run
