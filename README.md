# **Content Recommendation Platform**

## **Project Overview**
This platform is designed to provide content recommendations to users based on their preferences, browsing history, and the popularity of the content. It operates without AI, relying on predefined rules and user data to generate relevant recommendations. The platform is built using a microservices architecture to ensure scalability, modularity, and maintainability.

---

## **Microservices**

### **1. User Profile Service**
**Purpose**: Manages user data, preferences, and interaction history.

**Responsibilities**:
- **User Registration**: Allows users to create profiles with basic details like name, email, and interests.
- **Preferences Management**: Enables users to select their preferred categories or topics.
- **History Tracking**: Records the content a user consumes, including details like duration and completion status.

**Endpoints**:
- `POST /users`: Register a new user.
- `GET /users/{id}`: Retrieve user details.
- `PUT /users/{id}/preferences`: Update user preferences.
- `GET /users/{id}/history`: Fetch user interaction history.

---

### **2. Content Management Service**
**Purpose**: Handles the management of all available content on the platform.

**Responsibilities**:
- **Content Registration**: Allows administrators to add new articles, videos, or resources.
- **Categorization and Tagging**: Assigns categories and tags to content for easier search and filtering.
- **Availability Management**: Marks content as active or inactive based on its relevance.

**Endpoints**:
- `POST /content`: Register new content.
- `GET /content`: Fetch content list with filters (e.g., category, tags, status).
- `GET /content/{id}`: Retrieve specific content details.

**Content Structure Example**:
```json
{
  "id": 123,
  "title": "10 Tips for Remote Work",
  "category": "Workplace",
  "tags": ["remote", "productivity", "work"],
  "duration": 10,
  "publishedAt": "2024-11-01",
  "status": "active"
}
```

---

### **3. Recommendation Engine**
**Purpose**: Generates content recommendations based on predefined rules and user data.

**Recommendation Logic**:
1. **By Category**: Recommends content from user-preferred categories.
2. **By Tags**: Suggests content with tags similar to previously consumed items.
3. **By Popularity**: Highlights content that is widely consumed by other users in the same category.
4. **By Recency**: Suggests recently published content relevant to user preferences.
5. **Related Content**: Recommends content with similar tags or categories to what the user is currently viewing.

**Endpoints**:
- `GET /recommendations/{userId}`: Fetch recommendations for a specific user.

**Workflow**:
1. Queries user history and preferences.
2. Filters available content based on rules.
3. Returns a set of recommendations ranked by relevance.

---

### **4. Analytics Service**
**Purpose**: Collects and analyzes user interaction data to improve recommendations and content management.

**Responsibilities**:
- Tracks content interactions such as views and clicks.
- Records when users consume content (timestamps, durations, completion status).
- Provides insights into content popularity and user engagement.

**Endpoints**:
- `POST /analytics`: Log user interactions (e.g., viewing content).
- `GET /analytics/reports`: Generate reports on content popularity and usage.

---

### **5. Notification Service**
**Purpose**: Delivers notifications to users about new content and featured recommendations.

**Responsibilities**:
- Notifies users of new content in their preferred categories.
- Sends reminders to users who haven’t interacted with the platform recently.
- Allows users to customize notification preferences (e.g., email, SMS, push).

**Endpoints**:
- `POST /notifications`: Send notifications to a user or group of users.
- `GET /notifications/settings/{userId}`: Fetch user notification preferences.
- `PUT /notifications/settings/{userId}`: Update user notification preferences.

---

### **6. Authentication Service**
**Purpose**: Provides secure access to the platform using authentication and Role-Based Access Control (RBAC).

**Responsibilities**:
- **User Authentication**: Validates user credentials and issues access tokens.
- **Role-Based Access Control (RBAC)**: Restricts access to resources based on user roles.
- **Session Management**: Ensures secure and valid user sessions.

**Key Roles**:
- **Admin**: Full access to all services, including content creation and analytics.
- **Editor**: Limited to managing content but no access to analytics or user data.
- **User**: Can interact with recommendations and view content.

**Endpoints**:
- `POST /auth/login`: Authenticate users and generate JWT tokens.
- `POST /auth/register`: Register new users.
- `GET /auth/roles/{userId}`: Retrieve roles assigned to a user.
- `PUT /auth/roles/{userId}`: Update roles for a user.
- `POST /auth/logout`: Invalidate user sessions.

**Token Structure**:
- **Access Token**: Short-lived token for accessing resources.
- **Refresh Token**: Long-lived token for renewing access tokens.

**Middleware**:
- Protects all endpoints in other services by validating JWT tokens.
- Checks roles and permissions for each request.

**Workflow**:
1. Users log in and receive an access token with their assigned roles.
2. Tokens are included in the headers of all subsequent requests.
3. Services verify the token and check permissions before processing the request.

---

## **Content Collection Workflow**
1. **User Preferences**: Collected during registration or updated later by the user.
2. **Interaction History**: Every content interaction is recorded, including:
   - Content viewed.
   - Duration of interaction.
   - Timestamps.
3. **Categorization and Tagging**: Content is structured with categories and tags for better filtering.
4. **Popularity Metrics**: Tracks how many users engage with each piece of content and identifies trending items.
5. **Interaction Events**: Every user action (e.g., clicks, views) generates an event logged by the **Analytics Service**.

---

## **Benefits of This Approach**
- **Simplicity**: No complex algorithms or AI models are needed.
- **Customizable Rules**: Easily adjust rules to refine recommendations based on user feedback.
- **Scalability**: The microservices architecture allows each component to scale independently.
