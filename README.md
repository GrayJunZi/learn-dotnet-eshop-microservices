# learn-dotnet-eshop-microservices

.NET 8 微服务 DDD、CQRS、垂直切片架构/整洁架构。

## 一、介绍 (Introduction)

基于 .NET 平台构建微服务，将使用以下技术并基于云原生环境进行最佳实践的开发：

- 架构与设计原则
	- Layered Architecture ( 分层架构 )
	- Vertical Slice Architecture ( 垂直切片架构 )
	- DDD ( 领域驱动设计 )
	- Clean Architecture ( 整洁架构 )
	- CQRS ( 命令与查询职责分离 )
	- SOLID、DI
	- 中介者模式、代理模式、装饰器模式、选项模式
	- 发布订阅、缓存
- 服务通信与集成
	- ASP.NET WebA API
	- gRPC
	- RabbitMQ
	- MassTransit
	- YARP API Gateway
- 数据存储
	- PostgreSQL
	- SQL Server
	- SQLite
	- Redis
- 类库
	- Refit
	- Carter
	- Marten
	- MediatR
	- Mapster
	- MassTransit
	- FluentValidation
	- Entity Framework Core
- 容器化与编码 ( Containerization and Orchestration )
	- Docker
	- Dockerfile
	- Docker Compose

通过开发电商模块，并结合 NoSQL 数据库 ( PostgreSQL DocumentDB、Redis ) 和关系型数据库 ( SQL Server、SQLite )，通过 RabbitMQ 实现事件驱动的异步通信，同时利用 Yarp API 网关进行统一入口管理。来逐步实现一个完整的 .NET 微服务架构设计与实现。

将开发以下微服务及功能模块：

**商品目录 ( Category )**
- ASP.NET Core Minimal APIs 以及 .NET 8 和 C# 12 的最新特性
- 基于功能文件夹 ( Feature Folders ) 和 垂直切片架构 ( Vertical Slice Architecture ) 实现
- 基于 MediatR 实现 CQRS 模式
- 基于 MediatR 与 FluentValidation 的 CQRS 验证管道行为 ( Validation Pipeline Behaviours )
- 使用 Marten 库在 PostgreSQL 上实现 .NET 事务型文档数据库
- 使用 Carter 库定义 Minimal API 接口
- 横切关注点 ( 关注点分离 )：日志记录、全局异常处理和健康检查
- 用于在 Docker 环境中运行多容器的 Dockerfile 和 docker-compose 文件

**购物车 ( Basket )**
- 遵循 RESTful API 原则的 ASP.NET 8 Web API 应用，实现 CRUD 操作
- 使用 Redis 作为购物车数据库的分布式缓存
- 实现代理 ( Proxy )、装饰器 ( Decorator )、和缓存旁路 ( Cache-aside ) 设计模式
- 调用折扣 ( Discount ) gRPC 服务、实现服务间同步通信以计算商品最终架构
- 使用 MassTransit 和 RabbitMQ 发布 购物车结算 消息队列

**折扣 ( Discount )**
- ASP.NET 8 gRPC 服务端应用
- 与 购物车 ( Basket ) 微服务构建高性能的同步 gRPC 通信
- 通过定义 Protobuf 消息暴露 gRPC 服务
- 使用 Entity Framework Core ORM 及数据库迁移 ( Migrations )
- SQLite 数据库连接与容器化

**订单 ( Ordering )**
- 采用最佳实践实现 DDD、CQRS 和整洁架构 ( Clean Architecture )
- 使用 MediatR、FluentValidation 和 Mapster 开发 CQRS
- 使用领域事件 ( Domain Events ) 与集成事件 ( Integration Events )
- Entity Framework Core 的 Code-First 模式、迁移 ( Migrations ) 及 DDD 实体配置
- 通过 MassTransit 配置消费 RabbitMQ 的 购物车结算 事件队列
- SQL Server 数据库连接与容器化
- 使用 Entity Framework Core ORM，并在应用启动时自动迁移至 SQL Server

**购物应用 ( Shopping App )**
- 基于 Bootstrap4 和 Razor 模板的 ASP.NET Core Web 应用
- 使用 Refit 配合生成的 IHttpClientFactory 调用 Yarp API 网关接口
- ASP.NET Core Razor 工具：视图组件、局部视图、标签助手、模型绑定与验证、Razor区块等

**微服务通信机制**
- 服务间同步通信：gRPC
- 微服务异步通信：基于 RabbitMQ 消息代理服务
- 使用 RabbitMQ 的发布/订阅 ( Publish/Subscribe ) 主题交换模型 ( Topic Exchange )
- 使用 MassTransit 对 RabbitMQ 消息代理系统进行抽象封装
- 由 购物车 ( Basket ) 微服务发布 购物车结算 事件队列，订单 ( Ordering ) 微服务订阅该事件
- 创建 RabbitMQ 事件总线 ( EventBus ) 类库，供各微服务使用。

**Yarp API Gateway**
- Yarp 反向代理实现API网关、应用网关路由模式 ( Gateway Routing Pattern )
- Yarp 反向代理配置：路由 ( Route ) 、集群 ( Cluster )、路径 ( Path ) 、转换 ( Transform ) 、目标 ( Destinations )
- Yarp 反向代理配置中使用 FixedWindowLimiter 实现速率限制 ( Rate Limiting )
- 使用 API 网关进行 重路由

**Docker Compose 整合所有微服务**
- 微服务容器化
- 编排微服务及其支撑微服务 ( 数据库、分布式缓存、消息代理 )
- 覆盖环境变量以适配不同运行环境

在微服务中采用分层应用架构，实现 N层六边形架构 (核心层、应用层、基础设施层和表示层)，采用领域驱动设计 ( 实体、仓储、领域/应用服务、DTO等 )，目标是构建一个符合整洁架构原则的项目模板，同时贯彻松耦合、依赖倒置等架构最佳实践，并应用依赖注入、日志记录、验证、异常处理等设计模式。

### 课程目标

- 掌握使用设计模式、原则和最佳实践开发 .NET 8 微服务的核心技能，成为该领域的专家。
- 面向软件开发人员和架构师设计。
- 运用云原生微服务的设计模式与原则，落实行业最佳实践。
- 深入掌握 C# 12、.NET 8 和 ASP.NET 8 的最新特性，例如 Minimal API、主构造函数等。
- 全面理解 .NET 8 微服务架构，具备独立设计、开发和部署微服务应用的能力。

### 源码 ( Source Code )

aspnetrun 组织源码：
https://github.com/aspnetrun/run-aspnetcore-microservices

课程源码：
https://github.com/mehmetozkaya/EShopMicroservices

课程每章源码：
https://github.com/mehmetozkaya/EShopMicroservices-Udemy-Sections