# 🚀 Azure PaaS Deployment of .NET Web Application

This project demonstrates how to deploy a .NET web application using **Azure App Service (PaaS)** with full integration of **CI/CD pipelines, staging environments, Google authentication**, and **automated backup and scaling strategies**. The project setup leverages GitHub Actions for deployment and uses Azure-native services to achieve a robust, scalable, and production-ready environment.

---

## 🏗️ Project Architecture Overview

- **Platform**: Azure App Service (PaaS)
- **CI/CD**: GitHub Actions
- **Database**: Azure SQL Database
- **Authentication**: Google Federated Identity
- **Deployment Strategy**: Blue-Green with Staging Slots
- **Backup**: Azure Blob Storage (custom policy)
- **Scalability**: Vertical and Horizontal scaling

---

## 🔁 Continuous Integration and Deployment

This project utilizes **GitHub Actions** to automate the deployment process. After the application is developed (with the assistance of DeepSeek AI), it is committed to GitHub for continuous delivery.

➡️ [View Repository](https://github.com/your-repo-link)

You can fork the repository and deploy it locally or in your own Azure cloud environment.

---

## 🔐 Secure Database Connection

Sensitive information like the Azure SQL connection string is securely stored in **Azure App Service Environment Variables** instead of being hard-coded into the `appsettings.json` file. This ensures:

- Better security and secret management
- Seamless integration with Azure services
- Minimal configuration during deployment

---

## 🌐 Staging Environment (Zero Downtime Deployments)

To apply bug fixes and updates without downtime:

- A **staging slot** is configured with its own domain.
- Code updates are deployed to the staging slot.
- Once verified, changes are **swapped into production**.


---

## 🔐 Authentication Configuration

The application uses **out-of-the-box federated authentication with Google**, enabled through Azure App Service Authentication. This removes the need to implement custom login flows in code. You can alternatively implement your own authentication with ASP.NET Core Identity if preferred.

---

## 🧠 Backup Strategy

To ensure reliability, automated backup is enabled with customizable frequency. Although Azure performs hourly backups by default, we defined our own strategy and linked it to a dedicated **Azure Storage Account**.

📌 **Note**: Not all data is included in the backup. The following are *not* backed up:

- Content not stored in the App Service content store
- Files outside the `/home` directory
- Secrets from Key Vault (only references are stored)

---

## 📈 Scalability Configuration

Azure App Service provides built-in scalability:

### 🔄 Horizontal Scaling
- Scale-out to increase instance count.
- Scale-in to reduce instances during low traffic.

### ⬆️ Vertical Scaling
- Upgrade pricing tier for enhanced performance.
- Downgrade to reduce cost without losing core functionality.

Scalability is crucial to handle high user traffic and ensure optimal performance.

---

## 🎥 Demo and Walkthrough 

Video recordings of the project setup and functionality are available on Notion:

📺 [Watch Full Demo on YouTube](https://confusion-gardenia-15a.notion.site/Secure-and-scalable-NET-application-deployment-in-Azure-app-service-1eacc4e6d260801ebb83f29a54376e2b?pvs=4)

---

## 📦 Technologies Used

- ASP.NET Core
- Azure App Service
- Azure SQL Database
- Azure Storage Account
- Azure Portal & CLI
- GitHub Actions
- ShareX / Clipchamp (for recordings)
- Notion for Documentation

---

## 📌 Final Thoughts

This project showcases a modern cloud-based deployment strategy using Azure PaaS offerings. It demonstrates how developers can focus on building features while relying on Azure to manage infrastructure, security, backup, and scalability.


---

## 📬 Contact

**Author**: Abinet Degefa  
**LinkedIn**: [Abenet Degefe](https://www.linkedin.com/in/abenet-degefe-207769319/)  
**Email**: agonaferdegefe@gmail.com 
 
