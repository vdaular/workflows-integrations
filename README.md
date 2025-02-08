# Elsa Integrations

Welcome to the **Elsa Integrations** repository! This project aims to provide a collection of integration modules for [Elsa Workflows](https://elsa-workflows.github.io/), enabling seamless workflow automation across various third-party services.

## 🚀 Overview
Elsa Integrations aims to extend the capabilities of Elsa Workflows by providing modular integration packages for external platforms, such as:
- **Messaging & Communication** (Telegram, Slack, Discord, Microsoft Teams)
- **Email & Productivity** (Gmail, Outlook, Office 365)
- **Storage Services** (Google Drive, OneDrive, Azure Storage, Dropbox)
- **DevOps & Monitoring** (Azure DevOps, GitHub, Jenkins, Datadog)
- **Cloud Compute & Serverless** (Azure Functions, AWS Lambda, Google Cloud Functions)
- **E-Commerce & Payments** (Stripe, PayPal, Shopify, QuickBooks)
- **AI & Automation** (OpenAI, Google AI, AWS Comprehend)

## 📦 Structure
Each integration is structured as a standalone package under the `Elsa.Integrations` namespace. Example:
```
Elsa.Integrations.Gmail/
  ├── Services/
  ├── Activities/
  ├── AI/
Elsa.Integrations.Telegram/
  ├── Services/
  ├── Activities/
  ├── AI/
```

## ⚡ Getting Started
To install a specific integration:
```sh
dotnet add package Elsa.Integrations.Gmail
```
To enable it in Elsa Workflows:
```csharp
services.AddElsa()
        .AddGmailIntegration();
```

## 🔥 Contributing
We welcome contributions! See our [Contributing Guide](CONTRIBUTING.md) for more details.

## 📜 License
This repository is licensed under the **MIT License**.

---
