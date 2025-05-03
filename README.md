# Elsa Integrations

Welcome to the **Elsa Integrations** repository! This project provides a collection of integration modules for [Elsa Workflows](https://github.com/elsa-workflows/elsa-core), enabling seamless workflow automation across various third-party services.

---

## 🚀 Integration Status

Below is the current status of each integration. Checkboxes indicate implementation progress.

### 📨 Messaging & Communication
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Telegram** | Send & receive messages, file downloads | `Elsa.Integrations.Telegram` |  |
| [x] | **Slack** | Channel messages, user notifications | `Elsa.Integrations.Slack` | |
| [ ] | **Discord** | Bot commands, message triggers | `Elsa.Integrations.Discord` | |
| [ ] | **Microsoft Teams** | Chat automation, meeting reminders | `Elsa.Integrations.Teams` | |
| [x] | **Telnyx** | Telephony automation | `Elsa.Integrations.Telnyx` | |

### 📧 Email & Productivity
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Gmail** | Send, receive, label, draft emails | `Elsa.Integrations.Gmail` | |
| [ ] | **Outlook (Office 365)** | Email management via Microsoft Graph API | `Elsa.Integrations.Outlook` | |
| [ ] | **Google Calendar** | Event scheduling and updates | `Elsa.Integrations.GoogleCalendar` | |
| [ ] | **Microsoft Calendar** | Office 365 calendar integration | `Elsa.Integrations.Office365Calendar` | |

### 🗄️ Storage Services
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Google Drive** | Upload, download, manage files | `Elsa.Integrations.GoogleDrive` | |
| [ ] | **OneDrive** | File storage and access for Office 365 | `Elsa.Integrations.OneDrive` | |
| [ ] | **Azure Storage** | Blob storage management | `Elsa.Integrations.AzureStorage` | https://github.com/elsa-workflows/elsa-integrations/issues/1 |
| [ ] | **Dropbox** | Cloud storage and file sync | `Elsa.Integrations.Dropbox` | |

### 🛠 DevOps & Monitoring
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Azure DevOps** | Pipelines, repositories, work items | `Elsa.Integrations.AzureDevOps` | |
| [ ] | **GitHub** | PR automation, repo events | `Elsa.Integrations.GitHub` | |
| [ ] | **GitLab** | CI/CD triggers and repo management | `Elsa.Integrations.GitLab` | |
| [ ] | **Jenkins** | Pipeline automation and job execution | `Elsa.Integrations.Jenkins` | |
| [ ] | **Datadog** | Monitoring, logging, and alerts | `Elsa.Integrations.Datadog` | |

### ☁️ Cloud Compute & Serverless
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Azure Functions** | Serverless function triggers | `Elsa.Integrations.AzureFunctions` | |
| [ ] | **AWS Lambda** | Invoke and trigger Lambda functions | `Elsa.Integrations.AWSLambda` | |
| [ ] | **Google Cloud Functions** | Event-driven function automation | `Elsa.Integrations.GoogleCloudFunctions` | |

### 📊 CRM & Sales Automation
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Salesforce** | Lead management, opportunity tracking | `Elsa.Integrations.Salesforce` | [Open Issue](#) |
| [ ] | **HubSpot** | Contacts, deals, email automation | `Elsa.Integrations.HubSpot` | [Open Issue](#) |
| [ ] | **Zoho CRM** | Lead scoring, campaign tracking | `Elsa.Integrations.ZohoCRM` | [Open Issue](#) |
| [ ] | **Pipedrive** | Sales pipeline automation | `Elsa.Integrations.Pipedrive` | [Open Issue](#) |

### 💰 Payments & Finance
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **Stripe** | Payment processing, subscriptions | `Elsa.Integrations.Stripe` | |
| [ ] | **PayPal** | Transactions, refunds, invoicing | `Elsa.Integrations.PayPal` | |
| [ ] | **Square** | POS and e-commerce transactions | `Elsa.Integrations.Square` | |
| [ ] | **QuickBooks** | Invoice and expense automation | `Elsa.Integrations.QuickBooks` | |

### 🤖 AI & Automation
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **OpenAI** | GPT-based text generation, chatbots | `Elsa.Integrations.OpenAI` | |
| [ ] | **Google AI** | AI-enhanced search, translation | `Elsa.Integrations.GoogleAI` | |
| [ ] | **AWS Comprehend** | NLP services for text analysis | `Elsa.Integrations.AWSComprehend` | |
| [ ] | **Azure AI** | Vision, speech, language processing | `Elsa.Integrations.AzureAI` | |

### 🎥 Video & Streaming Platforms
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **YouTube** | Upload videos, retrieve video details, manage playlists | `Elsa.Integrations.YouTube` | [Open Issue](#) |
| [ ] | **Rumble** | Upload videos, fetch channel videos, manage content | `Elsa.Integrations.Rumble` | [Open Issue](#) |
| [ ] | **Twitch** | Live stream events, chat automation, clip management | `Elsa.Integrations.Twitch` | [Open Issue](#) |
| [ ] | **Vimeo** | Upload videos, manage privacy settings, get video analytics | `Elsa.Integrations.Vimeo` | [Open Issue](#) |

### 🏭 Industrial Communication Protocols
| Status | Integration | Description | Module Name | Issue |
|--------|------------|-------------|-------------|-------|
| [ ] | **OPC UA** | Browse nodes, Read/Write values, Subscribe/Unsubscribe nodes | `Elsa.Integrations.OPC.UA` | |
| [ ] | **Modbus** | Read/Write coils, Read discrete Inputs, Read/Write registers | `Elsa.Integrations.Modbus` | |
| [ ] | **MQTT Sparkplug** | Discover and Subscribe to topics, Publish messages | `Elsa.Integrations.MQTT.Sparkplug` | |

---

## 📦 Structure
Each integration is structured as a standalone package under the `Elsa.Integrations` namespace. Example:


```plaintext
...
├─azure/
│   ├── Elsa.Integrations.AzureServiceBus/
│   │   ├── README.md
│   │   ├── Services/
│   │   ├── Activities/
│   │   ├── AI/
│   │   └── ...
│   └── Elsa.Integrations.AzureStorage/
│       ├── README.md
│       ├── Services/
│       ├── Activities/
│       ├── AI/
│       └── ...
├─sql/
│   ├── README.md
│   ├── Elsa.Integrations.Sql/
│   │   ├── Services/
│   │   ├── Activities/
│   │   ├── AI/
│   │   └── ...
│   └── Elsa.Integrations.Sql.Sqlite/
│       ├── Services/
│       ├── Activities/
│       ├── AI/
│       └── ...
...
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
This repository is licensed under the [MIT License](https://github.com/elsa-workflows/elsa-integrations/blob/main/LICENSE).
