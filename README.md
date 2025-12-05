# learn-dotnet-eshop-microservices

.NET 10 微服务 DDD、CQRS、垂直切片架构/整洁架构。

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
	- ASP.NET Web API
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

**商品目录 ( Catalog )**
- ASP.NET Core Minimal APIs 以及 .NET 10 和 C# 12 的最新特性
- 基于功能文件夹 ( Feature Folders ) 和 垂直切片架构 ( Vertical Slice Architecture ) 实现
- 基于 MediatR 实现 CQRS 模式
- 基于 MediatR 与 FluentValidation 的 CQRS 验证管道行为 ( Validation Pipeline Behaviours )
- 使用 Marten 库在 PostgreSQL 上实现 .NET 事务型文档数据库
- 使用 Carter 库定义 Minimal API 接口
- 横切关注点 ( 关注点分离 )：日志记录、全局异常处理和健康检查
- 用于在 Docker 环境中运行多容器的 Dockerfile 和 docker-compose 文件

**购物车 ( Basket )**
- 遵循 RESTful API 原则的 ASP.NET 10 Web API 应用，实现 CRUD 操作
- 使用 Redis 作为购物车数据库的分布式缓存
- 实现代理 ( Proxy )、装饰器 ( Decorator )、和缓存旁路 ( Cache-aside ) 设计模式
- 调用折扣 ( Discount ) gRPC 服务、实现服务间同步通信以计算商品最终架构
- 使用 MassTransit 和 RabbitMQ 发布 购物车结算 消息队列

**折扣 ( Discount )**
- ASP.NET 10 gRPC 服务端应用
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

- 掌握使用设计模式、原则和最佳实践开发 .NET 10 微服务的核心技能，成为该领域的专家。
- 面向软件开发人员和架构师设计。
- 运用云原生微服务的设计模式与原则，落实行业最佳实践。
- 深入掌握 C# 12、.NET 10 和 ASP.NET 10 的最新特性，例如 Minimal API、主构造函数等。
- 全面理解 .NET 10 微服务架构，具备独立设计、开发和部署微服务应用的能力。

### 源码 ( Source Code )

aspnetrun 组织源码：
https://github.com/aspnetrun/run-aspnetcore-microservices

课程源码：
https://github.com/mehmetozkaya/EShopMicroservices

课程每章源码：
https://github.com/mehmetozkaya/EShopMicroservices-Udemy-Sections

## 二、微服务架构

软件架构的演进始于单体架构 (Monolithic)。在业务发展初期，单体架构凭借其简单易部署的特点，能快速满足业务需求。然而，随着业务规模的不断扩大，单体应用的代码量持续增加，维护成本上升，为了提升可维护性和开发效率，模块化单体架构 (Modular Monolithic) 应运而生，它将单体应用拆分为多个模块，实现了一定程度的解耦。

当用户量进一步增长，业务逻辑愈发复杂，单体架构的性能瓶颈逐渐凸显，如扩展困难、故障影响范围大等问题。为了应对这些挑战，微服务架构 (Microservices) 出现了。微服务将应用拆分为多个小型、独立且松耦合的服务，每个服务可独立开发、部署和扩展，有效提升了系统的灵活性和可扩展性。

随着云计算技术的发展，Serverless 架构成为新的趋势。这是一种基于事件驱动的架构风格，它将应用程序拆分为多个小型函数，每个函数负责处理特定的事件。开发人员无需关注服务器的管理和运维，只需专注于业务逻辑的实现，进一步降低了开发和运维成本。

### 1. 什么是微服务？

- 微服务是小型、独立且松耦合的服务，能够协同工作。
- 微服务通过定义明确的API相互通信。
- 微服务可以独立且自主地部署。
- 微服务支持多种不同的技术栈配合使用，具有技术无关性 ( 即不依赖特定技术 )。
- 每个服务都有独立的代码库，可由小型开发团队进行管理。
- 每个微服务拥有自己的数据库，不与其他服务共享。

### 2. 什么是微服务架构？

微服务架构风格是一种将单个应用程序开发为一组小型服务的方法，每个服务运行在自己的进程中，并通过轻量级通信机制（通常为 HTTP 或 gRPC API）进行交互。

- 微服务围绕业务功能进行构建，并可通过全自动化的部署流程实现独立部署。  
- 微服务架构将应用程序拆分为多个小型、独立的服务，这些服务通过明确定义的 API 进行通信，每个服务由小型、自治的团队负责维护。
- 微服务架构是一种云原生的架构方法，其中应用程序由许多松耦合、可独立部署的小型组件构成。 
- 微服务拥有各自的技术栈，通过 RESTful API 等方式进行相互通信，按业务能力组织，并具有明确的边界范围，即限界上下文（Bounded Contexts）。  
- 遵循单一职责原则（Single Responsibility Principle），即根据不同的服务来划分各自的职责。

> [Martin Fowlers Microservices article](https://martinfowler.com/articles/microservices.html)

### 3. 微服务特征 ( Characteristics )

- 通过服务实现组件化  
- 围绕业务能力组织  
- 以产品而非项目为导向  
- 采取智能的终端与简单的传输机制，即智能端点(smart endpoints)，哑管道（Dumb Pipes）  
- 实施去中心化的治理模式  
- 实现去中心化的数据管理
- 基础设施自动化  
- 为故障而设计（容错设计）

### 4. 微服务优势 ( Benefits )

**敏捷性、创新能力和更快的上市速度**
微服务架构使应用程序更易于扩展、更快速地开发，从而促进创新，并加速新功能的上市时间。

**灵活的可扩展性**
微服务可以独立扩展，因此你可以仅对资源需求较少的子服务进行横向扩展，而无需扩展整个应用程序。

**小型、专注的团队**
微服务应足够小，使得单一功能团队即可独立完成其构建、测试和部署。

**小型且隔离的代码库**
微服务不与其他服务共享代码或数据存储，这最大限度地减少了依赖关系，从而更易于添加新功能。

**易于部署**
微服务实现了持续集成与持续部署(CI/CD)，使得每个服务的部署更加简单和自动化。同时在某些方案失败时也能迅速回退到之前的状态。

**技术无关性**
微服务架构不依赖于任何特定的技术栈，开发人员可以根据业务需求选择最适合的技术。并在各自的服务中混合使用多种技术栈。

**弹性与故障隔离**
微服务具有容错能力，能够通过实现重试机制与断路器模式等方式正确处理故障。

**数据隔离**
根据微服务设计，各个数据库都是相互独立的。这样进行数据库更新会更容易，因为只要修改其中一个数据库即可。

### 5. 微服务面临的挑战 ( Challenges )

**复杂性**
每个服务本身更简单，但整个系统却变得更加复杂。当存在数百个微服务时，部署和通信将会变得非常繁琐。

**网络问题与延迟**
微服务通过服务间通信进行交互，因此需要应对网络问题。服务链路的增加会加剧延迟问题，并导致频繁的API调用。

**开发与测试**
与单体架构相比，在微服务架构中开发和端到端(E2E)测试这些流程更加困难。

**数据完整性**
每个微服务拥有自己的数据持久化机制，因此数据一致性将成为一项挑战。应尽可能遵循最终一致性原则。

**部署**
部署工作极具挑战性，需要投入大量资源来构建DevOps自动化流程和工具。微服务的复杂性使得人工部署将变得几乎不可能完成。

**日志与监控**
分布式系统需要将各种日志集中起来，以便全面了解系统的运行状况。通过这种集中式的日志管理方式，可以更容易地识别问题的根源。

**调试**
通过本地IDE进行调试已不再可行，因为在数十和数百个微服务的环境中，手动调试将变得非常困难。

### 6. 何时使用微服务架构

**确保你拥有实施微服务的“充分理由”**
你的应用程序是否真的需要依赖微服务来提升灵活性。如果你的应用程序确实需要具备快速上市的能力，即能够实现零延迟部署，并且各个组件能够独立更新，那么微服务无疑是一个非常有效的解决方案。

**通过逐步进行小规模修改来推进开发过程，同时将单进程的单体应用作为默认方案**
在开发过程中，可以通过逐步将单体应用程序中的某个模块拆分为微服务来实现迭代和重构。

**需要实现新功能的同时确保系统零停机时间**
当一个组织需要对现有功能进行修改，并且希望在不影响系统其他部分正常运行的情况下部署这些新功能时，就需要满足这一要求。

**需要能独立扩展应用程序的某一部分**
必须确保微服务能够拥有自己的数据存储机制，然而，数据一致性往往是一个难以解决的难题，这种情况下，需要采用最终一致性原则来确保数据的最终一致。

**使用不同数据库技术进行数据分区**
当需要为各种不同的使用场景存储和扩展数据时，微服务就显得极为实用，团队可以根据自身需求，逐步选择适合开发这些服务的技术。

**具备组织升级能力的自主团队**
微服务有助于推动团队和组织的演进与升级，组织需要将职责下放至各个团队，使每个团队都能自主决策并独立开发软件。

### 7. 何时不应使用微服务

**不要采用分布式单体架构**

**不要在没有DevOps或没有云服务支持下采用微服务架构**

**团队规模有限**
如果你的团队规模无法应对微服务带来的工作负载，那么只会导致项目交付的延迟。

对于小团队来说，采用微服务架构并不划算，因为这个团队本身就需要负责微服务的部署和管理工作。

**全新的产品或初创公司**
如果你正在开发一个全新的产品或初创企业，且在产品开发与迭代过程中需要做出重大调整，那么你不应该从采用微服务架构开始着手。

在重新设计业务架构时，微服务模式往往会带来高昂的成本。即便你最终取得了足够的成功，从而需要采用高度可扩展的架构，这些成本依然难以避免。

**共享数据库**
不要使用共享数据库(单一数据库)这种反模式。

### 8. 单体架构与微服务架构的对比

**应用程序架构**
单体应用的结构非常简单直接，由一个不可分割的完整单元构成。而微服务则具有复杂的结构，它由多种不同类型的服务和数据库组成。

**可扩展性**
单体应用程序是作为一个整体进行扩展的，而微服务则可以实现不均匀的扩展。这种特性促使许多企业将他们的应用程序迁移到微服务架构上。

**部署**
单体应用程序能够实现整个系统的快速、便捷部署；而微服务则能够保证系统零停机时间，并实现持续集成/持续部署的自动化流程。

**开发团队**
如果你的团队没有使用微服务和容器系统的经验，那么构建基于微服务的应用程序将会非常困难。

## 三、.NET 10/C# 12

### 1. .NET 10 新特性

**.NET Aspire**
专为构建云原生应用程序而设计的开发平台，它提供了一组工具和库，帮助开发人员更轻松地构建、测试和部署微服务架构的应用程序。

***核心.NET库*
序列化功能的增强、时间抽象机制的改进、UTF8编码的优化、处理随机性的相关方法，以及专注于性能优化的类型，例如 System.Numerics 和 System.Runtime.Intrinsics。

**衡量指标**
为 `Meter` 和 `Instrument` 对象添加键值对标签，从而在汇总的指标数据中实现更细致的区分。

**网络**
支持 HTTPS 代理，即使在代理环境下也能确保通信的安全性，从而提升隐私性和安全性。

**扩展库**
选项验证、LoggerMessageAttribute构造函数、扩展指标、托管的生命周期服务以及基于键值的依赖注入服务。

**垃圾回收**
可动态调整内存限制，这一功能在需要实现动态扩展的云服务场景中至关重要。

**反射性能的优化**
经过优化后，性能得到了提升，内存使用效率也更高了。此外，函数指针还新增了反射功能。

**原生AOT支持**
高效的编译与执行能力，尤其适用于云原生环境及高性能应用场景。

**.NET SDK**
更加强大且功能丰富，完全符合现代.NET 开发不断变化的需求。对 dotnet publish 和 dotnet pack 命令进行了优化升级。

### 2. C# 12 新特性

**主构造函数**
主要构造函数的适用范围不止`record`类型可以使用。现在，这些构造函数的参数在整个类体中都是有效的。

```csharp
public class Person(string name, int age)
{
    public string Name { get; } => name;
    public int Age { get; } => age;
}
```

**集合表达式**
更简洁的语法用于创建常见的集合对象。这简化了集合对象的初始化和操作方式。

```csharp
var numbers = new List<int> { 1, 2, 3, .. otherNumbers };
var numbers = [1, 2, 3, .. otherNumbers];
```

**内联数组**
通过允许开发人员在结构体类型中创建固定大小的数组，从而提升程序的性能。有助于优化内存布局并提升运行时性能。

```csharp
public struct Buffer
{
    public Span<int> InlineArray => MemoryMarshal.CreateSpan(ref _array[0], 10);

    private int[] _array;
}
```

**Lambda表达式中的可选参数**
Lambda表达式中参数的默认值。这一设计与为方法添加默认值的语法和规则保持一致，从而使Lambda表达式更加灵活。

```csharp
Func<int, int, int> add = (x, y = 1) => x + y;
Console.WriteLine(add(5));
```

**只读参数**
改进了 C# 中只读引用的传递方式。在涉及大型数据结构的场景中，优化了内存使用和性能。

```csharp
public void ProcessLargeData(in LargeData data)
{
    // 处理大型数据
}
```

**任意类型别名**
可以使用别名指令来包含任何类型的元素，而不仅仅是那些具有明确名称的类型。为元组、数组和指针等复杂数据类型创建语义别名。

```csharp
using Coordinate = System.ValueTuple<int, int>;
Coordinate location = (10, 20);
```

**顶层语句**
简化应用程序的入口点。无需将主要逻辑封装在 `Main` 方法中，可以直接在文件的顶层编写代码即可。

**全局引用**
使命名空间在整个项目中都能被使用。无需在每个文件中都重复声明这些命名空间，只需在某个统一的位置进行全局声明即可。

```csharp
global using System;
global using System.Collections.Generic;
```

**模式匹配**
提供了更丰富的语法，用于在代码中检查并解析各种数据值。

```csharp
public class Person
{
    public string Name { get; set; }
    public string Title { get; set; }
}

Person person = new Person { Name = "John", Title = "Manager" };
if (person is { Title: "Manager" })
{
    Console.WriteLine($"{person.Name} is a manager.");
}
```

**Switch模式匹配**
使用Switch表达式来处理枚举类型的情况，提供了更简洁和可读的代码。

```csharp
public State PerformOperation(Operation command) => command switch
{
    Operation.SystemTest => RunDiagnostics(),
    Operation.Start => StartSystem(),
    Operation.Stop => StopSystem(),
    Operation.Reset => ResetToReady(),
    _ => throw new ArgumentException("Invalid enum value for command", nameof(command)),
}
```

## 四、ASP.NET Core/Docker

### 1. 什么是 ASP.NET Core

- ASP.NET Core是一个跨平台、高性能的开源框架，用于构建现代的、支持云服务的、能够连接到互联网的应用程序。
- 开发Web应用程序和服务、物联网应用程序以及移动应用的后端系统。
- 支持构建高性能的 Web API 和服务。  
- 使用 ASP.NET Core 创建 Web API，充分利用其强大的功能来开发服务端点与用户界面。  
- 具备出色的性能、可扩展性和灵活性。  
- 体积轻量，支持跨平台开发，并提供了丰富的库和工具生态系统。专为云部署进行了优化，同时支持 CQRS 和事件驱动设计等现代架构模式。

**Minimal API**
在 ASP.NET 中构建快速且高效的 HTTP API 的简化方法。通过最少的编码和配置工作，即可创建出功能完备的 REST 端点，从而无需使用传统的开发框架或多余的控制器。无需使用传统的框架结构，也无需使用那些不必要的控制器组件——只需通过简洁明了的方式声明 API 路由和相应的操作功能即可。

### 2. 什么是 Docker

- Docker是一个用于开发、部署和运行应用程序的开源平台。
- 将应用程序与基础设施分离，这样你就能更快地交付软件产品。
- Docker的方法论在快速交付、测试和部署代码方面具有显著优势。
- 大幅缩短编写代码与在实际环境中运行代码之间的时间间隔。
- 将应用程序的部署过程自动化，使其成为可移植的、自给自足的容器形式，这些容器既可以在云端运行，也可以在本地环境中运行。

### 3. 使用Docker将应用程序容器化

1. 为应用程序编写 `Dockerfile` 文件。   
2. 使用 `Dockerfile` 构建 Docker 镜像。
3. 在任何机器上运行这些镜像，从而在镜像中创建出可运行的容器。

使用 `docker-compose` 来编排整个微服务应用程序，以便运行多个容器的Docker镜像。

## 五、微服务 Catalog.API

- `ASP.NET Core Minimal APIs`，用于构建高效的 HTTP API，提供了简洁的语法和功能，使开发人员能够快速创建 RESTful 服务。
- `Vertical Slice Architecture`，采用垂直切片架构时，将应用程序的功能按照垂直方向进行切分，每个功能模块都是一个独立的垂直切片。每个切片都包含了该功能模块的所有代码，包括控制器、服务、数据访问层等。
- `CQRS`，命令查询职责分离（Command Query Responsibility Segregation）是一种软件架构模式，用于将应用程序的读写操作分离开来。使用 `MediatR` 来实现CQRS模型。
- `Marten`，用于在 `PostgreSQL` 上操作事务性文档型数据库。 
- `Carter`，用于简化API接口定义的工具。
- `Mapster`，用于`DTO`类的对象映射。
- `FluentValidation`，对输入数据进行验证，并集成MediatR验证管道。
- `Dockerfile` 与 `docker-compose` 用于将微服务部署并运行在Docker环境中。

### 1. 微服务的端口号定义

| 微服务    | 本地环境   | Docker 环境 | Docker 内部 |
| -------- | --------- | --------- | --------- |
| Catalog  | 5000-5050 | 6000-6060 | 8080-8081 |
| Basket   | 5001-5051 | 6001-6061 | 8080-8081 |
| Discount | 5002-5052 | 6002-6062 | 8080-8081 |
| Ordering | 5003-5053 | 6003-6063 | 8080-8081 |

### 2. 微服务 Catalog.API 接口定义

| 方法	  | 请求地址            | 描述                  |
| ------ | ------------------ | -------------------- |
| GET    | /products          | 获取商品信息列表        |
| GET    | /products/{id}     | 获取指定商品信息        |
| GET    | /products/category | 根据分类获取商品信息列表 |
| POST   | /products          | 创建商品信息           |
| PUT    | /products/{id}     | 修改商品信息           |
| DELETE | /products/{id}     | 删除商品信息           |

### 3. 微服务 Catalog.API 技术分析

**垂直切片架构（Vertical Slice Architecture）**

常用于开发功能丰富、结构复杂的应用程序。将应用程序划分为不同的功能模块，每个模块都能贯穿整个应用程序的所有层级。与传统的多层架构不同，在传统架构中，应用程序是按水平方向进行划分的（如表示层、业务逻辑层、数据访问层等），而垂直切片架构则是按垂直方向进行划分的（每个功能模块都是一个独立的垂直切片）。

垂直切片架构的特性是每个部分都是独立且自成一体的，应用程序的不同组件之间的依赖关系得到了降低。具备可扩展性和可维护性，使得测试和部署流程变得更加高效。

垂直切片架构的优势是采用专注开发的方式，团队可以一次只专注于开发一个功能。这种方式简化了代码重构和系统升级的工作流程，因为某个部分的修改通常	不会影响到其他部分。这种开发模式与敏捷开发和DevOps实践高度契合，支持增量式开发和持续交付。

每个垂直切片都包含完整的功能模块：

- UI
- Application
- Domain
- Infrastructure

垂直切片架构与整洁架构的对比如下：

- VSA 强调围绕具体功能来组织软件开发功能，摒弃了那些繁琐的层级结构。
- CA 强调关注点分离与依赖关系管理。它将代码组织成不同的层次结构。
- VSA 模型中，开发团队专注于实现完整的系统功能，而这些功能往往需要涉及整个技术栈的各个层面。
- CA采用更加结构化的方法，确保业务逻辑与外部因素相互分离。
- VSA非常适合那些致力于开发具有众多功能的复杂应用程序的敏捷团队。
- CA非常适合那些需要长期维护、具备可扩展性，并且能够适应不断变化的业务需求的大规模应用场景。

**模式与原则（Patterns & Principles）**

- CQRS 模式（命令查询职责分离）：将操作划分为命令(写入数据) 和查询 (读取数据)。
- 中介者模式（Mediator Pattern）：通过一个中介者来协调对象之间的交互，减少对象间的直接依赖，并简化通信过程。
- ASP.NET Core 的依赖注入（DI）：依赖注入是一项核心功能，允许我们将所需的依赖项注入到类中。
- ASP.NET 10 的 Minimal API和路由机制：ASP.NET 10 的 Minimal API 简化了接口定义，提供轻量级的语法用于路由和处理HTTP请求。
- ORM 模式（对象关系映射）：通过对象关系映射技术将数据库的交互操作抽象出来，允许开发者能够使用高级代码操作数据库对象。

**类库与NuGet包**

- `MediatR` - 用于简化CQRS模式的实现过程。
- `Carter` - 负责路由和处理HTTP请求，能以清晰、简洁的代码轻松定义API接口。
- `Marten` - 将PostgreSQL用作文档数据库来使用，并充分利用其对JSON的强大支持来存储、查询和管理文档。
- `Mapster` - 是一个快速且可配置的对象映射工具，简化了对象之间映射的过程。
- `FluentValidation` - 用于构建强类型验证规则，确保输入数据在处理前的正确性。

### 4. 微服务 Catalog.API 项目创建

#### 4.1 创建项目结构

(1). 创建解决方案

```bash
dotnet new sln -n "learn-dotnet-eshop-microservices"
```

(2). 创建 Web API 项目

```bash
dotnet new webapi -n "Catalog.API"
```

(3). 将 Web API 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Catalog\Catalog.API"
```

(4). 创建 BuildingBlocks 类库

```bash
dotnet new classlib -n "BuildingBlocks"
```

(5). 将 BuildingBlocks 类库添加到解决方案中

```bash
dotnet sln add ".\BuildingBlocks\BuildingBlocks"
```

(6). 在 Catalog.API 项目中添加对 BuildingBlocks 类库的引用

```bash
dotnet add ".\Services\Catalog\Catalog.API" reference ".\BuildingBlocks\BuildingBlocks"
```

#### 4.2 安装 MediatR 类库

(1). 在 BuildingBlocks 项目中安装 MediatR 类库

```bash
dotnet add package MediatR
```

(2). 在 Catalog.API 项目中注册 MediatR 服务

```csharp
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
```

#### 4.3 安装 Mapster 类库

(1). 在 BuildingBlocks 项目中安装 Mapster 类库

```bash
dotnet add package Mapster
```

#### 4.4 安装 Carter 类库

(1). 在 Catalog.API 项目中安装 Carter 类库

```bash
dotnet add package Carter
```

(2). 在 Catalog.API 项目中注册 Carter 服务

```csharp
builder.Services.AddCarter();
```

(3). 在 Catalog.API 项目中启用 Carter 管道

```csharp
app.MapCarter();
```

#### 4.5 封装CQRS

(1). 定义命令接口

```csharp
public interface ICommand : ICommand<Unit>
{
    
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}
```

(2). 定义命令处理接口

```csharp
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{

}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{

}
```

(3). 定义查询接口

```csharp
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{

}
```

(4). 定义查询处理接口

```csharp
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{

}
```

#### 4.6 定义 Carter 接口

```csharp
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .WithSummary("Create Product")
            .WithDescription("Create Product")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
```

#### 4.7 添加全局引用

创建 `GlobalUsings.cs` 文件	

```csharp
global using Carter;
global using Mapster;
global using MediatR;
```

## 六、开发 Catalog.API 基础设施、处理程序以及相关接口

### 1. 什么是云原生微服务的支撑服务？

- 云原生微服务的支撑服务（Backing Services）是指微服务在运行过程中所依赖的外部组件。
- 这些服务为微服务提供多种功能支持，例如数据存储、消息传递、缓存和身份认证等。
- 数据库、消息系统和缓存服务等支撑服务被视为附加资源。
- 支撑服务独立于微服务本身，可在不修改微服务核心逻辑的情况下进行替换或更换。
- 支撑服务与微服务解耦，从而提升了系统的灵活性、可扩展性，并简化了维护工作。

### 2. 云原生微服务的支撑服务

- API 网关：用于管理微服务的入口流量，路由请求到相应的微服务。
- 服务网格（Service Mesh）：用于管理微服务之间的通信和流量控制。
- 身份认证（Authentication & Authorization）：用于保护微服务的访问和资源。
- 授权（Authorization）：用于定义和管理用户对资源的访问权限。
- 消息代理（Message Broker）：用于微服务之间的异步通信。
- 事件流（Event Streaming）：用于微服务之间的事件驱动通信。
- 日志系统：用于监控和追踪微服务的运行日志。
- 搜索系统：用于数据分析和搜索。
- 数据库：用于存储微服务的数据（关系型数据库或 NoSQL 数据库）。
- 分布式缓存：用于提高微服务的性能和响应时间。
- 对象存储：用于存储和检索非结构化数据，例如图片、视频和文档。

### 3. 微服务 Catalog.API 的基础数据结构

- Marten 是一种对象关系映射器（ORM），它充分利用了PostgreSQL的JSON功能。
- Marten 是一个功能强大的工具库，它能够将PostgreSQL转换为支持.NET事务处理的文档数据库系统。
- PostgreSQL的JSON列功能使我们能够将数据以JSON文档的形式进行存储和查询。
- 它结合了文档数据库的灵活性与关系型 PostgreSQL 数据库的可靠性。

### 4. 微服务部署策略

1. 使用 Docker Compose 构建本地开发环境以支持各项服务。
2. 完整的 Docker 环境编排。对微服务及依赖关系进行统一管理。
3. 未来在Kubernetes和云平台上进行部署。

#### 4.1 添加 Docker Compose 配置

(1). 添加 `docker-compose.yaml` 文件

该文件用于定义微服务的基础配置，包括数据库服务、网络、卷等核心配置。

```yaml
services:
  catalog.db:
    image: postgres
    
volumes:
  postgres_catalog:
    
```

(2). 添加 `docker-compose.override.yaml` 文件

该文件用于定义本地开发环境的 Docker Compose 配置。它会自动合并主配置文件。

```yaml
services:
  catalog.db:
    container_name: catalog.db
    environment:
      - POSTGRES_USER=postgres
      - POSTGRES_PASSWORD=postgres
      - POSTGRES_DB=CatalogDb
    restart: always
    ports:
      - "5432:5432"
    volumes:
      - postgres_catalog:/var/lib/postgresql/data/
```

### 5. 微服务 Catalog.API 基础设施层

#### 5.1 安装 Marten 类库

(1). 在 Catalog.API 项目中安装 Marten 类库

```bash
dotnet add package Marten
```

#### 5.2 在CQRS中使用 Marten

在主构造函数中注入 `IDocumentSession` 接口，用于与数据库进行交互。

```csharp
internal class CreateProductHandler (IDocumentSession documentSession)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };
        
        // 保存数据
        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
```

### 6. 自定义异常类

```csharp
public class ProductNotFoundException : Exception
{
    public ProductNotFoundException() : base("Product not found")
    {
    }

    public ProductNotFoundException(string message) : base(message)
    {
    }
}
```

## 七、开发 Catalog.API 横切关注点

- MediatR 管道行为 与 Fluent 验证库
- 日志记录与验证流程的行为特性
- 在 ASP.NET Core 中全局异常处理
- 使用 Marten 种子数据 为数据库进行数据填充
- 为 Catalog 的 PostgreSQL 数据库进行健康检查
- 为 GetProducts 查询实现分页
- 使用 Docker 和 Docker Compose 对微服务进行容器化与编排

### 1. MediatR Pipeline Behaviours (管道行为)

- MediatR的强大功能之一是“管道行为”，它允许在请求处理过程中添加额外的逻辑：验证、日志记录、异常处理以及性能监控。
- Pipeline Behaviors在MediatR库中充当中间件的角色，它们围绕着请求处理流程进行工作，从而实现了对各种跨领域问题的处理。

### 2. FluentValidation 验证器

- FluentValidation 用于构建强类型验证规则的库。
- FluentValidation 与 MediatR 集成在一起，以便在请求到达处理程序之前对其进行验证。
- FluentValidation 将验证规则定义在单独的类中，通过 Fluent API 风格来指定模型中每个属性必须满足条件。
- 将 MediatR 与 FluentValidation 结合使用，可以集成处理诸如数据验证这类跨模块的常见问题，从而使我们的代码更加简洁、更易于维护。

### 3. 使用 Marten 的初始基准数据填充种子数据

- 种子数据对于使用基线数据来初始化数据库至关重要。Marten为此提供了一个名为 IlnitialData 的功能。
- 实现 IInitialData 接口，以便用预定义的产品来初始化我们的 CatalogDb。
- 该接口使得 Marten 能在数据库首次初始化时自动完成数据填充工作。

### 4. ASP.NET Core 中的健康检查功能

- 在 ASP.NET Core 中，健康检查功能提供了一种监控应用程序及依赖项运行状态的方法。
- 健康检查功能通过应用程序以 HTTP 端点的形式对外提供。这些健康检查端点可以根据不同的实时监控需求进行配置。
- 容器编排器可以在检测到健康检查失败时，暂停滚动部署或重启相关容器。
- 负载均衡器可能会在检测到应用程序出现故障时，将流量从出现问题的实例重新路由到正常的实例上。

### 5. 集成 FluentValidation 与 MediatR 管道行为

(1). 在 BuildingBlocks 项目中安装 FluentValidation 类库

```bash
dotnet add package FluentValidation.DependencyInjectionExtensions
```

(2). 在 BuildingBlocks 中创建 ValidationBehavior 类

```csharp
public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(x => x.Errors.Any())
            .SelectMany(x => x.Errors)
            .ToList();

        if (failures.Count > 0)
            throw new ValidationException();
        
        return await next();
    }
}
```

(3). 在 Catalog.API 中注册 ValidationBehavior 类

```csharp
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
```

(4). 在 Catalog.API 添加 CreateProductCommand 验证器

```csharp
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        
        RuleFor(x => x.Categories)
            .NotEmpty()
            .WithMessage("Categories is required");

        RuleFor(x => x.ImageFile)
            .NotEmpty()
            .WithMessage("Image file is required");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}
```

(5). 在 Catalog.API 中注册所有的 FluentValidation 验证器

```csharp
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
```

### 6. 全局异常处理

#### 6.1 自定义异常类

(1). 创建 NotFoundException 异常类

```csharp
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key) : base($"Entity '{name}' ({key}) was not found")
    {
        
    }
}
```

(2). 创建 InternalServerException 异常类

```csharp
public class InternalServerException : Exception
{
    public InternalServerException(string message):base(message)
    {
        
    }

    public InternalServerException(string message, string details) : base(message)
    {
        Details = details;
    }
    
    public string? Details { get; }
}
```

(3). 创建 BadRequestException 异常类

```csharp
public class BadRequestException : Exception
{
    public BadRequestException(string message):base(message)
    {
        
    }

    public BadRequestException(string message, string details) : base(message)
    {
        Details = details;
    }
    
    public string? Details { get; }
}
```

#### 6.2 全局异常处理中间件

(1). 在 BuildingBlocks 项目中安装 FluentValidation 类库

```bash
dotnet add package FluentValidation
dotnet add package FluentValidation.AspNetCore
```

(2). 创建全局异常处理中间件

```csharp
public class CustomerExceptionHandler(ILogger<CustomerExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {Time}",
            exception.Message,
            DateTime.UtcNow);

        (string Detail, string Title, int StatusCode) details = exception switch
        {
            InternalServerException => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
            ),
            ValidationException => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            BadRequestException => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            NotFoundException => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };

        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = httpContext.Request.Path,
        };

        problemDetails.Extensions.Add("TraceId", httpContext.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ExceptionErrors", validationException.Errors);
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
```

(3). 在 Catalog.API 中注册全局异常处理中间件

```csharp
builder.Services.AddExceptionHandler<CustomerExceptionHandler>();
```

(4). 在 Catalog.API 中配置全局异常处理中间件

```csharp
app.UseExceptionHandler(options => { });
```

### 7. 日志统一处理

(1). 在 BuildingBlocks 项目中创建日志统一处理中间件

```csharp
public class LoggingBehavior<TRequet, TResponse>(ILogger<LoggingBehavior<TRequet, TResponse>> logger)
    : IPipelineBehavior<TRequet, TResponse>
    where TRequet : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequet request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle Request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequet).Name, typeof(TResponse).Name, request);

        var timer = Stopwatch.StartNew();

        var response = await next(cancellationToken);

        timer.Stop();
        var duration = timer.Elapsed;
        if (duration.Seconds > 3)
        {
            logger.LogWarning("[PERFORMANCE] The Request {Request} took {Duration} seconds.",
                typeof(TRequet).Name, duration.Seconds);
        }

        logger.LogInformation("[END] Handle {Request} with {Response}", 
            typeof(TRequet).Name, typeof(TResponse).Name);
        return response;
    }
}
```

(2). 在 Catalog.API 中注册日志统一处理中间件

```csharp
builder.Services.AddMediatR(config =>
{
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
```

### 8. 初始化数据

(1). 在 Catalog.API 项目中创建种子数据

```csharp
public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
            return;

        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "IPhone X",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Categories = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung 10",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Categories = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "Huawei Plus",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-3.png",
            Price = 650.00M,
            Categories = new List<string> { "White Appliances" }
        },
        new Product()
        {
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "Xiaomi Mi 9",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-4.png",
            Price = 470.00M,
            Categories = new List<string> { "White Appliances" }
        },
        new Product()
        {
            Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
            Name = "HTC U11+ Plus",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-5.png",
            Price = 380.00M,
            Categories = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
            Name = "LG G7 ThinQ",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Categories = new List<string> { "Home Kitchen" }
        },
        new Product()
        {
            Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
            Name = "Panasonic Lumix",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Categories = new List<string> { "Camera" }
        }
    };
}
```

(2). 在 Catalog.API 项目中注册种子数据

```csharp
builder.Services.InitializeMartenWith<CatalogInitialData>();
```

### 9. 分页功能

(1). 在 Catalog.API 项目中接收分页查询参数

```csharp
public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapGet("/products", async ([AsParameters] GetProductsRequest request,ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var result = await sender.Send(query);

                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .WithDescription("Get Products")
            .WithSummary("Get Products")
            .Produces<GetProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
```

(2). 在 Catalog.API 项目中根据分页查询参数进行分页查询

```csharp
public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsHandler(
    IDocumentSession documentSession)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
        return new GetProductsResult(products);
    }
}
```

### 10. 健康检查

#### 10.1 添加默认健康检查

(1). 在 Catalog.API 项目中添加健康检查服务

```csharp
builder.Services.AddHealthChecks();
```

(2). 在 Catalog.API 项目中添加健康检查端点

```csharp
app.UseHealthChecks("/health");
```

#### 10.2 添加 PostgreSQL 健康检查

(1). 在 Catalog.API 项目中安装 `AspNetCore.HealthChecks.Npgsql` 类库

```bash
dotnet add package AspNetCore.HealthChecks.Npgsql
```

(2). 在 Catalog.API 项目中注册 PostgreSQL 健康检查

```csharp
builder.Services.AddHealthChecks()
    .AddNpgsql(builder.Configuration.GetConnectionString("Database"));
```

(3). 在 Catalog.API 项目中安装 `AspNetCore.HealthChecks.UI.Client` 类库

```bash
dotnet add package AspNetCore.HealthChecks.UI.Client
```

(4). 在 Catalog.API 项目中添加健康检查 UI 中间件

```csharp
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
```

### 11. Docker 容器化与编排

#### 11.1 Docker 容器化

(1). 在 Catalog.API 项目中添加 Dockerfile 文件

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Catalog/Catalog.API/Catalog.API.csproj", "Services/Catalog/Catalog.API/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "Services/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Catalog.API"
RUN dotnet build "./Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]
```

#### 11.2 Docker 编排

(1). 在 Catalog.API 项目中修改 docker-compose.yml 文件

```yaml
services:
  catalog.db:
    image: postgres
    
  catalog.api:
    image: ${DOCKER_REGISTRY-}catalogapi
    build:
      context: .
      dockerfile: Services/Catalog/Catalog.API/Dockerfile
    
volumes:
  postgres_catalog:
```

(2). 在 Catalog.API 项目中修改 docker-compose.override.yml 文件

```yaml
services:
  catalog.db:
    container_name: catalog.db
    environment:
      - POSTGRES_USER=postgres
      - POSTGRES_PASSWORD=postgres
      - POSTGRES_DB=CatalogDb
    restart: always
    ports:
      - "5432:5432"
    volumes:
      - postgres_catalog:/var/lib/postgresql/data/
        
  catalog.api:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ConnectionStrings__Database=Server=catalog.db;Port=5432;Database=CatalogDb;User Id=postgres;Password=postgres;Include Error Detail=true
    depends_on:
      - catalog.db
    ports:
      - "6000:8080"
      - "6001:8081"
    volumes:
      - ${APPDATA}/Microsoft/UserSecrets:/home/app/.microsoft/usersecrets:ro
      - ${APPDATA}/ASP.NET/Https:/home/app/.aspnet/https:ro
```

#### 11.3 运行 Docker 编排

(1). 在 Windows 环境中应该先运行以下命令生成开发证书

```bash
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\Https\localhost.pfx -p "123456"
dotnet dev-certs https --trust
```

(2). 在 `docker-compose.override.yml` 文件中添加开发证书配置

```yaml
services:
  catalog.api:
    volumes:
      - ${USERPROFILE}/.aspnet/UserSecrets:/home/app/.microsoft/usersecrets:ro
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
```

(1). 在 Catalog.API 项目中打开终端，运行以下命令

```bash
docker-compose up -d
```

## 八、微服务 Basket.API

- `ASP.NET Core Minimal APIs`，用于构建高效的 HTTP API，提供了简洁的语法和功能，使开发人员能够快速创建 RESTful 服务。
- `Vertical Slice Architecture`，采用垂直切片架构时，将应用程序的功能按照垂直方向进行切分，每个功能模块都是一个独立的垂直切片。每个切片都包含了该功能模块的所有代码，包括控制器、服务、数据访问层等。
- `CQRS`，命令查询职责分离（Command Query Responsibility Segregation）是一种软件架构模式，用于将应用程序的读写操作分离开来。使用 `MediatR` 来实现CQRS模型。
- `Marten`，用于在 `PostgreSQL` 上操作事务性文档型数据库。 
- `Redis` 分布式缓存 与 `Marten` 实现仓储模式。
- `Carter`，用于简化API接口定义的工具。
- `Mapster`，用于`DTO`类的对象映射。
- `FluentValidation`，对输入数据进行验证，并集成MediatR验证管道。
- `Dockerfile` 与 `docker-compose` 用于将微服务部署并运行在Docker环境中。

### 1. 微服务 Basket.API 的领域模型

购物车的领域模型主要包括：

- `ShoppingCart` - 购物车
- `ShoppingCartItem` - 购物车项目
- `BasketCheckout` - 购物车结账

以购物车结账为例，这一操作会触发一系列相关事件，从而实现系统的集成。

### 2. 微服务 Basket.API 的应用场景

#### 2.1 购物车管理

- 客户可以添加、删除、更新购物车中的商品。
- 客户可以查看购物车中的商品列表。

#### 2.2 购物车结账

- 客户可以在购物车中选择商品并结账。
- 结账过程会触发一系列事件，如订单创建、库存更新等。
- 发布事件将发送至RabbitMQ消息代理服务器。

#### 2.3 gRPC 操作

- 当使用购物车获取折扣时，会从商品价格扣除相应的折扣金额。

### 3. 微服务 Basket.API 接口定义

| 方法	  | 请求地址            | 描述              |
| ------ | ------------------ | ---------------  |
| GET    | /basket/{userName} | 获取购物车信息列表  |
| POST   | /basket/{userName} | 购物车插入/更新操作 |
| DELETE | /basket/{userName} | 删除购物车         |
| POST   | /basket/checkout   | 购物车结账         |

### 4. 微服务 Basket.API 的基础数据结构

购物车微服务拥有两个数据存储系统：

1. `Marten` 文档数据库
2. `Redis`  分布式缓存

- Marten是一个功能强大的工具库，它利用PostgreSQL的JSON列功能，将PostgreSQL转换成了一个支持.NET事务处理的文档数据库。
- Redis是一种强大的内存数据存储系统及分布式缓存工具，非常适合用于微服务架构。

### 5. 微服务 Basket.API 项目创建

#### 5.1 创建项目结构

(1). 创建 Web API 项目

```bash
dotnet new webapi -n "Basket.API"
```

(2). 将 Web API 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Basket\Basket.API"
```

(3). 在 Basket.API 项目中添加对 BuildingBlocks 类库的引用

```bash
dotnet add ".\Services\Basket\Basket.API" reference ".\BuildingBlocks\BuildingBlocks"
```

#### 5.2 添加领域模型

在 Basket.API 项目中的文件夹 `Models` 添加领域模型类

```bash
public class ShoppingCart
{
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; }
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    public ShoppingCart()
    {
        
    }
}

public class ShoppingCartItem
{
    public int Quantity { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
}
```

### 6 安装 Carter 类库

(1). 在 Basket.API 项目中安装 Carter 类库

```bash
dotnet add package Carter
```

(2). 在 Basket.API 项目中注册 Carter 服务

```csharp
builder.Services.AddCarter();
```

(3). 在 Basket.API 项目中启用 Carter 管道

```csharp
app.MapCarter();
```

### 7. 注册 MediatR 服务

注册 `MediatR` 服务并添加验证管道和日志管道。

```csharp
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
```

### 8. 安装 Marten 类库

(1). 在 Basket.API 项目中安装 Marten 类库

```bash
dotnet add package Marten
```

(2). 在 Basket.API 项目中注册 Marten 服务

指定 `ShoppingCart` 表中的 `UserName` 字段为主键。

```csharp
var database = builder.Configuration.GetConnectionString("Database");
builder.Services.AddMarten(options =>
    {
        options.Connection(database);
        options.Schema.For<ShoppingCart>().Identity(x => x.UserName);
    })
    .UseLightweightSessions();
```

(3). 添加仓储

在 Basket.API 项目中的 `Data` 文件夹中添加 `IBasketRepository` 接口，用于操作购物车数据。

```csharp
public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
}
```

在 Basket.API 项目中的 `Data` 文件夹中添加 `BasketRepository` 类，实现 `IBasketRepository` 接口。

```csharp
public class BasketRepository(IDocumentSession documentSession) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var basket =  await documentSession.LoadAsync<ShoppingCart>(userName, cancellationToken);
        return basket ?? throw new BasketNotFoundException(userName);
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart,
        CancellationToken cancellationToken = default)
    {
        documentSession.Store(shoppingCart);
        await documentSession.SaveChangesAsync(cancellationToken);
        return shoppingCart;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        documentSession.Delete<ShoppingCart>(userName);
        await documentSession.SaveChangesAsync(cancellationToken);
        return true;
    }
}
```

注册 `BasketRepository` 服务

```csharp
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
```

### 9. 注册自定义全局异常

(1). 在 Basket.API 中注册自定义全局异常处理中间件

```csharp
builder.Services.AddExceptionHandler<CustomerExceptionHandler>();
```

(2). 在 Basket.API 中配置全局异常处理中间件

```csharp
app.UseExceptionHandler(options => { });
```

## 九、微服务 Basket.API 构建分布式缓存系统

### 1. 缓存模式

#### 1.1 为什么选择 Redis 作为分布式缓存解决方案？

- Redis 采用键值对的数据存储，以其高性能而闻名。
- Redis 常被用于缓存、会话存储、发布/订阅系统等领域。
- Redis 提供了基于内存的数据存储方式，因此数据访问速度快。
- Redis 提供了多种数据结构，能适用于多种不同的使用场景。
- Redis 使各种服务能够快速访问共享数据，从而减轻数据库的压力。

#### 1.2 如何在微服务中使用 Redis 作为分布式缓存？

- 实现代理模式(Proxy Pattern)、装饰器模式(Decorator Pattern)，并使用 `Scrutor` 库来实现缓存旁路模式及缓存失效机制。
- 开发带缓存的仓储，并使用 `Scrutor` 库对其进行装饰。
- 通过 `docker-compose` 在多容器Docker环境中配置 `Redis` 作为分布式缓存。

通过减轻数据库的负担并加快数据检索速度，从而提升系统性能。

#### 1.3 微服务的缓存旁路(Cache-Aside)模式

缓存旁路模式可以通过减少昂贵的数据库调用次数，来提升微服务架构的性能。

1. 当客户端需要访问数据时，它会首先检查这些数据是否已经存在于缓存中。
2. 如果数据已经存在于缓存中，客户端就会从缓存中获取该数据，并将其返回给调用者。
3. 如果数据不在缓存中，客户端会从数据库中获取该数据，将其存储到缓存中，然后再将其返回给调用者。

- 某些缓存系统提供了读穿透(read-through)，以及写穿透(write-through)和写回(write-behind)等机制。
- 对于那些不支持缓存的系统来说，应用程序有责任自行管理缓存，并在发生缓存未命中时及时更新缓存内容。
- 微服务是实现“缓存旁路”模式的一个很好的例子。通常，我们会使用一种分布式缓存系统，这种缓存系统会被多个服务共同使用。

#### 1.4 微服务的缓存旁路模式的缺点(Drawbacks)

- 缓存可能会增加系统的复杂性，并且并不适用于所有情况。
- 当数据库或数据存储中的数据发生更新时，可能需要使缓存失效或重新加载缓存中的数据。
- 这可能需要微服务之间进行额外的协调。
- 如果缓存位于距离使用它的微服务较远的地方，那么就可能会引入额外的延迟。

#### 1.5 什么是代理模式(Proxy Pattern)和装饰器模式(Decorator Pattern)？

**代理模式：**

- 它为另一个对象提供了一个占位符，用于控制对该对象的访问。这种模式会创建一个代理对象，该代理对象充当那些原本是针对原始对象发出的请求的中间处理者。
- 懒加载、访问控制以及日志记录功能。这就好比设置了一个“守门人”——在真正访问目标对象之前，会先执行一些额外的操作或检查流程。

**装饰器模式：**

动态地为对象添加新功能，而不会改变其原有的结构。这种方法依赖于一系列装饰器类，这些装饰器类用于扩展原始类的功能，同时无需修改原始类的代码。

#### 1.6 使用 Scrutor 库实现装饰器模式

- `Scrutor` 库是一个用于 .NET 应用程序的容器注册库，它可以帮助我们自动注册和配置依赖注入容器中的服务。
- 我们可以使用 `Scrutor` 库来实现装饰器模式，从而为我们的服务添加额外的功能。
- 例如，我们可以使用 `Scrutor` 库来为我们的服务添加缓存功能，从而提高服务的性能。

### 2. 使用 Redis 实现仓储层的缓存机制

#### 2.1 安装 Redis 库

在 Basket.API 项目中安装 Redis 库。

```bash
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis
```

#### 2.2 为仓储层添加缓存装饰器

```csharp
public class CachedBasketRepository(
    IBasketRepository basketRepository,
    IDistributedCache distributedCache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var cachedBasket = await distributedCache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrWhiteSpace(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket);
        }

        var basket = await basketRepository.GetBasket(userName, cancellationToken);
        await distributedCache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart,
        CancellationToken cancellationToken = default)
    {
        var basket = await basketRepository.StoreBasket(shoppingCart, cancellationToken);

        await distributedCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket),
            cancellationToken);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await basketRepository.DeleteBasket(userName, cancellationToken);
        await distributedCache.RemoveAsync(userName, cancellationToken);
        return true;
    }
}
```

#### 2.3 配置 Redis 缓存服务

在 Basket.API 项目的 `Program.cs` 文件中配置 Redis 缓存服务。   

```csharp
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});
```

### 3. 使用 Scrutor 库注册缓存装饰器

#### 3.1 注册缓存装饰器

在 Basket.API 项目的 `Program.cs` 文件中注册 `CachedBasketRepository` 类。

```csharp
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
```

### 4. Docker Compose 配置

在 `docker-compose.yaml` 文件中添加 Redis 服务。

```yaml
services:
  distribute.cache:
    image: redis
```

在 `docker-compose.override.yaml` 文件中添加 Redis 服务的配置。

```yaml
services:
  distribute.cache:
    container_name: distribute.cache
    restart: always
    ports:
      - "6379:6379"
```


### 5. 健康检查

#### 5.1 注册健康检查服务

(1). 在 Basket.API 项目中注册健康检查服务

```csharp
builder.Services.AddHealthChecks();
```

#### 5.2 添加 PostgreSQL 健康检查服务

(1). 在 Basket.API 项目中安装 `AspNetCore.HealthChecks.Npgsql` 类库

```bash
dotnet add package AspNetCore.HealthChecks.Npgsql
```

(2). 在 Basket.API 项目中注册 PostgreSQL 健康检查

```csharp
builder.Services.AddHealthChecks()
    .AddNpgsql(builder.Configuration.GetConnectionString("Database"));
```

#### 5.3 添加 Redis 健康检查服务

(1). 在 Basket.API 项目中安装 `AspNetCore.HealthChecks.Redis` 类库

```bash
dotnet add package AspNetCore.HealthChecks.Redis
```

(2). 在 Basket.API 项目中注册 Redis 健康检查服务

```csharp
builder.Services.AddHealthChecks()
    .AddRedis(builder.Configuration.GetConnectionString("Redis"));
```

#### 5.4 添加健康检查UI中间件

(1). 在 Basket.API 项目中安装 `AspNetCore.HealthChecks.UI.Client` 类库

```bash
dotnet add package AspNetCore.HealthChecks.UI.Client
```

(2). 在 Basket.API 项目中添加健康检查 UI 中间件

```csharp
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
```

## 十、微服务 Discount.Grpc

### 1. 微服务通信方式

#### 1.1 同步还是异步这是一个问题

**同步通信：**

- 同步通信是通过 `HTTP`、`HTTPS` 或 `gRPC` 协议来返回响应的。
- 同步通信指的是，客户端发送请求后，会阻塞等待服务端返回响应，只有当服务端返回响应后，客户端才会继续执行后续逻辑。

**异步通信：**

- 异步通信可以通过 `AMQP( Advanced Message Queuing Protocol )` 协议来实现，客户端通过 `Kafka` 和 `RabbitMQ` 等消息队列来发送和接收消息。
- 异步通信指的是，客户端发送请求后，不会阻塞等待服务端返回响应，而是继续执行后续逻辑。
- 异步通信通常用于需要处理耗时操作的场景，例如，调用远程服务、访问数据库等。
- 异步通信可以提高系统的吞吐量和响应速度，但是也会增加系统的复杂性和维护成本。

#### 1.2 同步通信与最佳实践

- `GraphQL` 是一种基于 `HTTP` 协议的同步通信协议，当微服务中需要处理结构化且灵活的数据时，是一个不错的选择。
- `gRPC` 在同步通信场景下，性能更好，因为它是基于 `HTTP/2` 协议的，而 `HTTP/2` 协议支持多路复用，即多个请求可以在一个连接上并发传输，而 `HTTP/1.1` 协议只能一个请求一个连接。
- `WebSocket` 在双向实时通信场景下，性能更好，因为它是基于 `TCP` 协议的，而 `TCP` 协议是一种可靠的、有序的、基于连接的协议，它可以在客户端和服务端之间建立一个持久的连接，从而实现实时通信。

### 2. 高性能的远程过程调用技术 gRPC

- gRPC 是由 Google 开发的一种高性能的远程过程调用技术(Remote Procedure Call)，它基于 `HTTP/2` 协议，支持多路复用、流控、压缩等功能，从而提高了系统的吞吐量和响应速度。
- gRPC 依赖于 Protocol Buffers 来定义服务接口和数据结构，从而实现了跨语言的通信。
- Protocol Buffers(简称 Protobuf) 能够为多种语言生成跨平台的客户端和服务端绑定代码(即 Stub 代码)，从而简化了微服务之间的通信。

#### 2.1 gRPC 的工作原理

- RPC 是一种 客户端/服务端 通信方式，它使用函数调用来传递数据，而不是传统的HTTP请求。
- 在 gRPC 中，客户端应用程序可以像调用本地对象一样，直接调用另一台机器上的服务器应用程序的方法。
- 在服务器端，会实现这个接口，并运行一个 gRPC 服务器来处理来自客户端的请求。
- 在客户端，会使用一个 stub 类，该 stub 类提供了与服务器相同的方法。
- gRPC 客户端和服务器可以在不同的环境中相互通信。

### 3. 微服务 Discount.Grpc 技术分析

- `ASP.NET gRPC API` 构建一个性能卓越的跨服务 gRPC 通信系统，以支持折扣和购物车微服务之间的数据交互。
- `gRPC` 与 `protobuf` 来暴露 gRPC 服务。
- `SQLite` 用于存储数据信息。
- `Entity Framework Core` 用于和SQLite数据库进行交互，通过数据迁移来简化数据访问过程并确保系统高性能运行。
- `N-Layer 架构` 多层架构实现。
- `Docker Compose` 将微服务进行容器化部署。

#### 3.1 应用程序架构

**传统N层(N-Layer)架构：**

- **表示层(Presentation Layer)**：负责处理用户请求和响应，与用户进行交互，并将用户输入的数据传入到业务层。
- **业务逻辑层(Business Logic Layer)**：负责实现应用程序的业务逻辑，与表示层进行通信。
- **数据访问层(Data Access Layer)**：负责与数据库进行交互，执行数据操作。

**类库与NuGet包**

- 通用工具包：Mapster、FluentValidation
- gRPC：Grpc.AspNetCore
- 数据库：Microsoft.EntityFrameworkCore.Sqlite、Microsoft.EntityFrameworkCore.Tools

#### 3.2 目录结构

- `Models` 领域层：存储 SQLite 实体类。
- `Data` 数据访问层：包含EFCore的 上下文对象和迁移文件。
- `Service` 业务逻辑层：存储 gRPC 服务。
- `Protos` 表示层：使用 gRPC 暴露 API 接口。

#### 3.4 微服务 Discount.Grpc 基础数据结构

- 将优惠券信息存储至 SQLite 数据库中。
- SQLite是一个用C语言编写的库，它实现了一个小巧、快速、自包含、高可靠性且功能完备的SQL数据库引擎。
- 这种方案因其简单性和高效性而被选中，尤其适用于处理像折扣这类小规模数据的情况。它被直接集成到应用程序中，因此无需额外搭建基础设施。

### 4. 微服务 Discount.Grpc 服务定义

| 方法 (gRPC)       | 请求地址                | 描述    |
| ----------------- | --------------------- | ------- |
| GetDiscount       | GetDiscountRequest    | 获取折扣 |
| CreateDiscount    | CreateDiscountRequest | 创建折扣 |
| UpdateDiscount    | UpdateDiscountRequest | 更新折扣 |
| DeleteDiscount    | DeleteDiscountRequest | 删除折扣 |

### 5. 微服务 Discount.Grpc 项目创建

#### 5.1 创建目录结构

(1). 创建 GRPC 项目

```bash
dotnet new grpc -n "Discount.Grpc"
```

(3). 将 GRPC 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Discount\Discount.Grpc"
```

#### 5.2 微服务 Discount.Grpc 领域模型

折扣的领域模型主要包括：

- `Coupon` - 优惠券

当客户将商品添加到购物车时，微服务 Basket 会调用折扣服务的API，以获取该商品的最新折扣信息。

```csharp
public class Coupon
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
}
```

### 6. 集成 Entity Framework Core Sqlite

#### 6.1 安装 Entity Framework Core Sqlite 类库

(1). 安装 Entity Framework Core Sqlite 类库

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

(2). 安装 Entity Framework Core Tools 类库
```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

(3). 创建 DbContext 类 并设置种子数据

```csharp
public class DiscountDbContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }

    public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "iPhone X", Description = "iPhone X Discount", Amount = 150 },
            new Coupon { Id = 2, ProductName = "Huawei", Description = "Huawei Discount", Amount = 150 }
        );
    }
}
```

(3). 注册 DbContext 服务
```csharp
builder.Services.AddDbContext<DiscountDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Database")));
```

#### 6.2 数据库迁移

生成迁移文件，并应用到数据库中。

**Visual Studio 下的迁移命令**
```bash
Add-Migration InitialCreate
Update-Database
```

**.NET Cli 下的迁移命令**
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### 6.3 自动迁移

(1). 在 Discount.Grpc 项目中的 Data 文件夹下创建一个 Extensions 静态类。

```csharp
public static class Extensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountDbContext>();
        dbContext.Database.Migrate();
        return app;
    }
}
```

(2). 在 Discount.Grpc 项目中的 `Program.cs` 文件中添加以下内容，以启用自动迁移：

```csharp
app.UseMigration();
```

### 7. 安装 Mapster 类库

在 Discount.Grpc 项目中安装 Mapster 类库，以实现对象映射。

```bash
dotnet add package Mapster
```

### 8. 创建 Grpc 服务

(1). 在 Discount.Grpc 项目中的 `Protos` 文件夹下创建 `discount.proto` 文件。

```proto
syntax = "proto3";

option csharp_namespace = "Discount.Grpc";

package discount;

service DiscountProtoService {
  rpc GetDiscount (GetDiscountRequest) returns (CouponModel);
  rpc CreateDiscount (CreateDiscountRequest) returns (CouponModel);
  rpc UpdateDiscount (UpdateDiscountRequest) returns (CouponModel);
  rpc DeleteDiscount (DeleteDiscountRequest) returns (DeleteDiscountResponse);
}

message GetDiscountRequest {
  string productName = 1;
}

message CouponModel {
  int32 id = 1;
  string productName = 2;
  string description = 3;
  int32 amount = 4;
}

message CreateDiscountRequest {
  CouponModel coupon = 1;
}

message UpdateDiscountRequest {
  CouponModel coupon = 1;
}

message DeleteDiscountRequest {
  string productName = 1;
}

message DeleteDiscountResponse {
  bool success = 1;
}
```

(2). 在 Discount.Grpc 项目中的 `Services` 文件夹下创建 `DiscountService` 类。

```csharp
public class DiscountService(
    DiscountDbContext dbContext,
    ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName)
                     ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount" };

        logger.LogInformation("Discount is retrieved for ProductName: {ProductName}, {Amount}", coupon.ProductName,
            coupon.Amount);

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully created for ProductName: {ProductName}", coupon.ProductName);

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully updated for ProductName: {ProductName}", coupon.ProductName);

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
        ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with ProductName={request.ProductName} is not found."));

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully deleted for ProductName: {ProductName}", coupon.ProductName);

        return new DeleteDiscountResponse { Success = true };
    }
}
```

(3). 在 Discount.Grpc 项目中的 `Discount.Grpc.csproj` 文件中添加以下内容，以启用 protobuf 服务：
```xml
<ItemGroup>
    <Protobuf Include="Protos\discount.proto" GrpcServices="Server" />
</ItemGroup>
```

(4). 在 Discount.Grpc 项目中的 `Program.cs` 文件中添加以下内容，以启用 gRPC 服务：

```csharp
app.MapGrpcService<DiscountService>();
```

### 9. Docker Compose 编排

#### 9.1 添加 Dockerfile 配置

在 Discount.Grpc 项目中添加 `Dockerfile` 文件，以定义微服务的 Docker 镜像。

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Discount/Discount.Grpc/Discount.Grpc.csproj", "Services/Discount/Discount.Grpc/"]
RUN dotnet restore "Services/Discount/Discount.Grpc/Discount.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Discount.Grpc"
RUN dotnet build "./Discount.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Discount.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grpc.dll"]
```

#### 9.2 添加 Docker Compose 配置

(1). 在 `docker-compose.yaml` 文件中添加以下内容，以定义微服务的基础配置。

```yaml
services:
  discount.grpc:
    image: ${DOCKER_REGISTRY-}discount.grpc
    build:
      context: .
      dockerfile: Services/Discount/Discount.Grpc/Dockerfile
```

(2). 在 `docker-compose.override.yaml` 文件中添加以下内容，以定义本地开发环境的 Docker Compose 配置。

```yaml
services:  
  discount.grpc:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ASPNETCORE_Kestrel__Certificates__Default__Password=123456
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/home/app/.aspnet/https/localhost.pfx
      - ConnectionStrings__Database=Data Source=DiscountDb
    ports:
      - "6002:8080"
      - "6062:8081"
    volumes:
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
```

## 十一、从 Basket 微服务中调用 Discount 相关的 Grpc 服务

- gRPC 客户端的集成：Basket 服务将作为 gRPC 客户端，调用微服务 Discount 下的 gRPC 服务。
- 消费折扣服务：折扣将应用于购物车中的商品，并据此计算出最终价格。
- 重新进行容器化处理：确保 Basket 服务与 Discount 服务进行通信。

### 1. 在 Basket 服务中引用 Discount 服务中的 Proto 文件

(1). 在 `Basket.API.csproj` 文件中添加以下内容，以引用 Discount 服务中的 Proto 文件。

```xml
<ItemGroup>
    <Protobuf Include="..\..\Discount\Discount.Grpc\Protos\discount.proto" GrpcServices="Client">
        <Link>Protos\discount.proto</Link>
    </Protobuf>
</ItemGroup>
```

(2). 安装 `Grpc.AspNetCore` 包，以启用 gRPC 客户端功能。

```bash
dotnet add package Grpc.AspNetCore
```

### 2. 在 Basket 服务中调用 Discount 服务并计算最终价格

注入 `DiscountProtoServiceClient` 客户端，以调用 Discount 服务中的 gRPC 方法。

```csharp

public class StoreBasketHandler(
    IBasketRepository basketRepository,
    DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await DeductDiscount(command.Cart, cancellationToken);
        
        var basket = await basketRepository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(basket.UserName);
    }

    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await discountProtoServiceClient.GetDiscountAsync(new GetDiscountRequest
            {
                ProductName = item.ProductName,
            }, cancellationToken: cancellationToken);

            item.Price -= coupon.Amount;
        }
    }
}
```

### 3. 配置 gRPC 客户端

在 Basket.API 项目中的 `Program.cs` 文件中添加以下内容，以注册 `DiscountProtoServiceClient` 客户端。

```csharp
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]);
});
```

### 4. Docker Compose 配置

#### 4.1 修改 Basket 服务配置

在 `docker-compose.override.yaml` 文件中修改 `basket.api` 配置信息，以支持对 Discount 服务的调用。

```yaml
services:
  basket.api:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ASPNETCORE_Kestrel__Certificates__Default__Password=123456
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/home/app/.aspnet/https/localhost.pfx
      - ConnectionStrings__Database=Server=basket.db;Port=5432;Database=BasketDb;User Id=postgres;Password=postgres;Include Error Detail=true
      - ConnectionStrings__Redis=distribute.cache:6379
      - GrpcSettings__DiscountUrl=https://discount.grpc:8081
    depends_on:
      - basket.db
      - distribute.cache
      - discount.grpc
    ports:
      - "6001:8080"
      - "6061:8081"
    volumes:
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
```

#### 4.2 处理证书问题

当 Basket.API 服务调用 Discount.Grpc 时会出现证书问题，可以通过以下代码忽略证书。

```csharp
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]);
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
    };
    
    return handler;
});
```

## 十二、微服务 Ordering.API

使用 DDD、CQRS 和 Clean Architecture 构建微服务系统。

### 1. 微服务 Ordering 整洁架构分层

**领域层 (Domain Layer)：**
- 战术层面的DDD实现方式，包括实体、值对象和聚合体。
- 在DDD中贫血领域模型与充血领域模型的选择。
- 领域事件与集成事件。

**基础设施层 (Infrastructure Layer)：**
- Entity Framework Core 9 中的代码优先模式、数据迁移以及SQL Server数据库连接。
- Entity Framework Core 9 中的关系 与 DDD 值对象映射（使用 ComplexType 和 ComplexProperty）。
- 程序启动时自动迁移并填充种子数据。
- Entity Framework Core 9 拦截器（SaveChangesInterceptor）的使用方法。

**应用层 (Application Layer)：**
- 使用 MediatR 实现 CQRS模式，包括命令对象与命令处理器。
- 使用 MediatR 管道行为组件进行验证以及记录日志。
- 使用 MediatR 的 INotificationHandler 处理器来处理领域事件(Domain Event)。

**API层 (API Layer)：**
- 使用 Carter 来定义最小化的 API接口。
- 自定义异常处理机制。


### 2. 微服务 Ordering.API 的应用场景

#### 2.1 订单管理

- 客户可以添加、删除、更新订单中的商品。
- 客户可以查看订单中的商品列表。

#### 2.2 订单结算

- 客户进行购物车结算：使用 `MassTransit` 组件，从RabbitMQ中接收购物车结算 `BasketCheckout` 事件。
- 订单履约(Order Fulfilment)：
  - 订单创建后，通过 `MassTransit` 组件将订单发送到消息队列。
  - 订单服务监听消息队列，一旦收到订单消息，就会创建一个新的订单。
- 触发 `OrderCreated` 领域事件，该事件会引发集成事件的执行。

### 3. 微服务 Ordering.API 接口定义

| 方法	  | 请求地址                       | 描述                  |
| ------ | ----------------------------- | -------------------- |
| GET    | /orders                       | 分页获取订单信息        |
| GET    | /orders/{orderName}           | 按订单名称获取订单信息   |
| GET    | /orders/customer/{customerId} | 根据分类获取商品信息列表 |
| POST   | /orders                       | 创建订单信息           |
| PUT    | /orders                       | 修改订单信息           |
| DELETE | /orders/{id}                  | 删除订单信息           |

### 4. 微服务 Ordering 的基础数据结构

订单微服务将使用以下存储系统：

1. SQL Server 关系型数据库

- SQL Server 将用于存储订单信息以及订单中的各项明细信息。
- Entity Framework Core 被选为ORM工具，采用了 代码优先(Code-First) 的开发方法。
- 领域模型被映射到了 Entity Framework Core 实体中，并遵循DDD中的一些概念，例如，聚合根与值对象。

### 5. 微服务 Ordering 技术分析

#### 5.1 DDD、CQRS与整洁架构(Clean Architecture)

整洁架构被分为四个层次，各个项目都遵循这种架构规范进行开发，其中类库项目在开发过程中也会参照这些规范进行设计。

#### 5.2 模式与原则（Patterns & Principles）

共同原则：
- SOLID、KISS、YAGNI、SoC、DIP 原则与依赖注入为基础。

领域层模式：
- 领域实体模式与实体基类
- 贫血领域模型与充血领域模型
- 值对象模式
- 聚合模式，也被称为聚合根或根实体
- 强类型 IDs 模式
- 领域事件与集成事件

基础设施数据层模式：
- 仓储模式
- EF Core ORM，代码优先模式、迁移、数据库初始化(种子数据)
- 值对象复合类型与EF聚合根实体
- 使用 EF Core 中的 ModelBuilder 进行实体配置
- 使用 EF Core 与 MediatR 发起并处理领域事件

领域层模式：
- CQRS 模式
- 命令与命令处理模式
- 中介者模式与 MediatR 管道行为模式 
- FluentValidation 与 日志

展示层模式：
- Minimal APIs

交互流程： 

Domain -> Infrastructure -> Application -> Presentation

#### 5.3 设计原则 - SOLID

- 单一职责原则(Single Responsibility)，每个组件与模块都应只负责一项功能。
- 开闭原则(Open-Closed Principle)，我们应该确保它能够不改变现有架构的前提下进行扩展。
- 里氏替换原则(Liskov Substitution Principle)，系统之间可以很容易地进行相互替换。在我们的例子中，我们可以使用插件服务来实现这种替换，因为这些插件服务可以非常方便地进行替换。
- 接口隔离原则(Interface Segregation Principle)，任何代码都不应被迫依赖于那么它不需要的接口。
- 依赖倒置原则(Dependency Inversion Principle)，高层模块不应该依赖于低层模块，而应该依赖于抽象。

#### 5.4 设计原则 - 职责分离(SoC)

- 职责分离(Separation of Concerns, SoC)，每个组件或模块都应该只负责一项功能，而不是多项功能。
- 将软件系统分解为多个组件或模块，通过拆分系统来降低其复杂性。
- 高内聚(High Cohesion)，组件或模块内部的元素应该紧密相关，而不是松散耦合。
- 低耦合(Low Coupling)，组件或模块之间的依赖关系应该最小化，以减少系统的维护成本。

#### 5.5 领域驱动设计(Domain-Driven Design, DDD)

整洁架构的特点：模块化、可扩展、可测试且易于维护。

- 领域驱动设计自2003年 Eric Evans 提出以来，已经成为了一种非常流行的软件设计方法。
- 它的核心理念是将软件系统的设计与领域问题进行紧密的结合，以实现对业务逻辑的准确理解和实现。
- DDD 强调领域模型的重要性，领域模型是对业务领域的抽象和建模，它包含了业务规则、业务逻辑和业务概念。
- DDD 还强调领域驱动的开发方法，即开发人员应该直接参与到业务领域的讨论和建模中，而不是依赖于技术实现。
- DDD 还强调领域事件的重要性，领域事件是领域模型中的一种特殊类型的事件，它表示业务领域中的重要变化或发生。
- DDD 还强调领域服务的重要性，领域服务是领域模型中的一种特殊类型的服务，它表示业务领域中的一些操作或功能，而不是简单的 CRUD 操作。

#### 5.6 DDD 类型

**战略级DDD(Strategic DDD)**

- 理解并构建业务领域模型。
- 涉及到识别不同的领域、它们的子领域，以及这些领域之间是如何相互作用的。

**战术级DDD(Tactical DDD)**

- 提供了实现细节以及相关的设计模式
- 包括实体、值对象、聚合根、仓储、领域事件、集成事件、领域服务等。

#### 5.7 DDD 概念

**领域(Domain)**

它代表了业务领域或业务需求范围。

**子领域(SubDomain)**

它代表了整个领域内的某个特定专业领域。

**通用语言(Ubiquitous Language)**

是开发人员与领域专家之间共同使用的一套通用语言，旨在确保沟通的清晰性和一致性，这套语言将贯穿于整个开发过程中。

**有界上下文(Bounded Context)**

- 将那些彼此紧密相关的范围归为一类，我们可以将这些范围视为逻辑上的边界。
- 这种逻辑边界将复杂问题领域中的各个子问题划分成独立自洽的部分。
- 每个有界上下文都有用自己的数据库架构、代码模型，以及负责开发该系统的团队。

**上下文映射模式(Context Mapping Pattern)**

- 确定应用程序中所有的有界上下文及其逻辑边界。
- 它是一种用于界定不同领域之间逻辑的方法。

**有界上下文模式(Bounded Context Pattern)**

有界上下文模式是微服务拆分过程中的核心设计模式，特别适用于处理需要高度协作且具有一定复杂性的领域问题。

在领域驱动设计(DDD)中，每个领域模型都会定义其特有的通用语言，即"领域特定语言"，并将系统结构划分为多个独立的组件，这些组件就是所谓的"有界上下文"。

DDD解决复杂问题的关键方法是将整体拆分为更小、更易处理的子问题。一个复杂领域通常包含多个子域，其中一些子域可以组合成组，共同遵循特定规则并承担相应职责。

"有界上下文"本质上是一种逻辑边界，它具有双重含义：一方面是将功能上紧密相关的范围组合在一起；另一方面是将复杂问题领域中相对独立、自成一体的子问题部分明确区分开来。

从战略层面来看，领域驱动设计着重于定义系统的大规模架构模型，明确业务规则，实现单元间的松耦合设计，并构建各单元之间的上下文关系图。

而在战术层面，领域驱动设计则更关注软件的具体实现过程，提供了一系列实用的设计模式，帮助开发人员构建出可行且高效的软件系统。

#### 5.8 整洁架构(Clean Architecture)

该设计方法由 Robert C. Martin 提出，它的核心理念是将软件系统的设计与业务领域进行紧密的结合，以实现对业务逻辑的准确理解和实现。

**框架独立性(Independent of Frameworks)**

该系统并未与特定的框架绑定，因此能适应各种框架和工具的变化。

**可测试(Testable)**

业务规则可以在不使用UI、数据库、Web服务器或任何外部组件的情况下进行测试。

**与UI无关(UI Agnostic)**

UI可以很容易地进行更换，而无需对系统的其他部分进行任何修改。

**与数据库无关(Database Agnostic)**

业务规则并不依赖于特定的数据库，而是与底层的数据存储系统相互分离。

**与外部系统无关(External System Agnostic)**

业务规则对外部世界一无所知，它们处于孤立的状态之中。

#### 5.9 整洁架构的层次结构

**实体层(Entities Layer)/领域层(Domain Layer)**

- 包括了适用于整个企业的业务规则。
- 实体封装了最为通用且层次最高的规则。

**用例层(Use Cases Layer)/应用层(Application Layer)**

- 包含了特定于该应用程序的业务规则。
- 涵盖了系统中所有的用例，并对这些用例进行了实现。

**接口适配层(Interface Adapters Layer)/基础设施层(Infrastructure Layer)**

- 将数据从最适合特定用例和数据主体的格式转换成最适合外部系统使用的格式。

**框架与驱动层(Frameworks and Drivers Layer)/基础设施与外部因素(Infrastructure/External Concerns)**

- 最外层由各种框架和工具组成，例如数据库和Web框架等。
- 通过包括UI、数据库、外部接口等。

### 6. 微服务 Ordering.API 项目创建

#### 6.1 创建 Ordering.Domain 领域层

(1). 创建类库项目

```bash
dotnet new classlib -n "Ordering.Domain"
```

(2). 将 Domain 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Ordering\Ordering.Domain"
```

#### 6.2 创建 Ordering.Application 应用层

(1). 创建类库项目

```bash
dotnet new classlib -n "Ordering.Application"
```

(2). 将 Application 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Ordering\Ordering.Application"
```

(3). 在 Ordering.Application 项目中添加对 BuildingBlocks 类库的引用

```bash
dotnet add ".\Services\Ordering\Ordering.Application" reference ".\BuildingBlocks\BuildingBlocks"
```

(4). 在 Ordering.Application 项目中添加对 Domain 项目的引用

```bash
dotnet add ".\Services\Ordering\Ordering.Application" reference ".\Services\Ordering\Ordering.Domain"
```

#### 6.3 创建 Ordering.Infrastructure 基础设施层

(1). 创建类库项目

```bash
dotnet new classlib -n "Ordering.Infrastructure"
```

(2). 将 Infrastructure 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Ordering\Ordering.Infrastructure"
```

(3). 在 Ordering.Infrastructure 项目中添加对 Application 项目的引用

```bash
dotnet add ".\Services\Ordering\Ordering.Infrastructure" reference ".\Services\Ordering\Ordering.Application"
```

#### 6.4 创建 Ordering.API 项目

(1). 创建 Web API 项目

```bash
dotnet new webapi -n "Ordering.API"
```

(2). 将 Web API 项目添加到解决方案中

```bash
dotnet sln add ".\Services\Ordering\Ordering.API"
```

(3). 在 Ordering.API 项目中添加对 Application 项目的引用

```bash
dotnet add ".\Services\Ordering\Ordering.API" reference ".\Services\Ordering\Ordering.Application"
```

(4). 在 Ordering.API 项目中添加对 Infrastructure 项目的引用

```bash
dotnet add ".\Services\Ordering\Ordering.API" reference ".\Services\Ordering\Ordering.Infrastructure"
```

#### 6.5 依赖注入分离

在各层中都增加一个 `DependencyInjection` 文件夹，用于存放依赖注入相关的代码。

(1). 在 Ordering.API 项目中添加依赖注入相关的代码

```csharp
namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
```

(2). 在 Application 项目中添加依赖注入相关的代码

```csharp
namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
```

(3). 在 Infrastructure 项目中添加依赖注入相关的代码
```csharp
namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        return services;
    }
}
```

最终，在 Ordering.API 项目中调用各层中添加依赖注入的代码，如下：

```csharp
builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);
```

#### 6.6 全局命名空间引入

在各层中都添加一个 `GlobalUsings.cs` 文件，用于存放全局使用的命名空间。

(1). 在 Ordering.API 项目中添加全局命名空间

```csharp
global using Ordering.API;
```

(2). 在 Application 项目中添加全局命名空间

```csharp
global using Ordering.Application;
```

(3). 在 Infrastructure 项目中添加全局命名空间

```csharp
global using Ordering.Infrastructure;
```

###  7. Ordering.Domain 使用领域驱动设计构建领域层

#### 7.1 战术领域驱动设计(Tactical Domain-Driven Design)

**实体**

- 实体是一种标识符(Id)，而非属性来识别的对象。
- 标识符使得每个实体都具有唯一性，即使它们的其他属性完全相同。
- 实体用于表示系统中那些具有唯一标识和生命周期的对象。

**值对象**

- 值对象是一种用于描述某种特征或属性的对象，但它本身并不具备身份识别的功能。
- 值对象用于描述那些在概念层面上没有独立身份的领域特征。
- 它们是不可变的，通常被用来封装复杂的属性。

**聚合**

- 聚合是由一组领域对象（实体和值对象）组成的集合，这些对象可以被视为一个整体来处理。
- 聚合体必然包含一个名为“聚合根”的组件。
- 为相关对象划定一个边界。在该边界范围内的操作应当确保对聚合数据所做的更改保持一致性。

**聚合根**

- 聚合根是聚合中的主要实体，外部对象正是通过它与聚合体进行交互的。
- 它为聚合提供了访问接口，确保聚合的不变性得到维护，并保持数据的一致性。

#### 7.2 基础类型偏执(Primitive Obsession)

Primitive Obsession是一种代码坏味道现象：在这种情况下，程序中会使用诸如字符串、整数、Guid之类的原始类型来表示业务领域的概念，从而导致代码含义模糊且容易出错。

如果使用 GUID 或字符串作为 orderld、customerld 或 productld 的标识符，就很容易将它们混淆在一起，因为它们的类型其实是一样的。

#### 7.3 强类型 Ids 模式

为领域中的每种类型的Id创建不同的标识符。这样能让代码更具表现力，同时更不容易出错。

这明确了系统期望接收哪种类型的标识符，并防止用户误用了本应使用的标识符类型（例如订单编号），而使用了另一种类型的标识符。

#### 7.4 贫血模型实体(Anemic Domain Model Entity)

贫血模型几乎不包含任何业务逻辑，本质上就是带有 getter 与 setter 方法的数据结构。

这令这类实体显得贫瘠，因为它仅仅包含了数据，而完全缺乏任何领域逻辑或相关行为。

#### 7.5 充血模型实体(Rich Domain Model Entity)

实体既包含了数据，也包含了相关的业务逻辑。

#### 7.6 贫血模型实体与充血模型实体的对比

**贫血模型实体：**

- 业务逻辑分散在应用程序的各个部分中，通常存在于不同的服务模块中。
- 实体只是简单的数据容器而已。
- 这会导致维护难度增加，同时也难以理解业务逻辑。

**充血模型实体：**

- 将业务逻辑封装在各个实体内部。
- 更贴近现实世界的业务场景。
- 虽然设计起来可能更为复杂，但这样构建出的模型会更加易于维护，且各个部分之间的逻辑联系也会更加紧密。

#### 7.7 领域事件(Domain Event)

- 领域事件代表过去发生的某个事实，同一服务边界内的其他部分需要对这一变化作出响应。
- 领域事件（Domain Event）是指在领域模型（domain model）内部发生的业务事件，它通常表示某个领域操作产生的副作用或后续影响。
- 用于确保同一领域内各个数据集之间的一致性。

#### 7.8 领域事件与集成事件的对比

**领域事件：**

- 在单一的领域内进行发布和消费。严格遵循微服务/领域本身的边界限制。
- 表示在整体范围内发生了某种事情。

**集成事件：**

- 用于在各种上下文或微服务之间传递状态变化或事件信息。
- 整个系统对特定领域事件的反应
- 通过消息队列异步发送(经由消息代理，即 Message Broker)

#### 7.9 定义抽象实体

在 `Abstractions` 文件夹中，定义一个通用的实体接口 `IEntity<TId>`，其中 `TId` 是实体的标识符类型。

```csharp
public interface IEntity<TId> : IEntity
{
    public TId Id { get; set; }
}

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}
```

定义一个抽象类 `Entity<TId>`，实现 `IEntity<TId>` 接口。

```csharp
public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}
```

#### 7.10 定义领域事件

(1). 安装 NuGet 包 `MediatR`。

```bash
dotnet add package MediatR
```

(2). 定义领域事件接口 `IDomainEvent`。

```csharp
public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.Now;

    public string EventType => GetType().AssemblyQualifiedName;
}
```

#### 7.11 定义聚合根

(1). 定义聚合根接口 `IAggregate<TId>`，其中 `TId` 是聚合根的标识符类型。

```csharp
public interface IAggregate<TId> : IAggregate, IEntity<TId>
{
    
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    IDomainEvent[] ClearDomainEvents();
}
```

(2). 定义聚合根抽象类 `Aggregate<TId>`，实现 `IAggregate<TId>` 接口。

```csharp
public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => 
        _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent) => 
        _domainEvents.Add(domainEvent);
    
    public IDomainEvent[] ClearDomainEvents()
    {
        var dequeuedEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return dequeuedEvents;
    }
}
```

#### 7.12 定义值对象

(1). 定义地址值对象。

```csharp
public record Address
{
    public string Name { get; }
    public string Email { get; }
    public string AddressLine { get; }
    public string Country { get; }
    public string State { get; }
    public string Zipcode { get; }
}
```

(2). 定义支付值对象。

```csharp
public record Payment
{
    public string CardName { get; }
    public string CardNumber { get; }
    public string Expiration { get; }
    public string CVV { get; }
    public int PaymentMethod { get; }
}
```

#### 7.13 定义枚举

(1). 定义订单状态枚举。

```csharp
public enum OrderStatus
{
    Draft = 1,
    Pending = 2,
    Completed = 3,
    Cancelled = 4,
}
```

#### 7.14 定义模型

(1). 定义订单模型。

它是一个聚合根，用于表示订单的状态和行为。

```csharp
public class Order : Aggregate<Guid>
{
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }

    public Address ShippingAddress { get; private set; }
    public Address BillingAddress { get; private set; }
    public Payment Payment { get; private set; }
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }
}
```

(2). 定义订单项模型。

它是一个实体，用于表示订单中的商品项。

```csharp
public class OrderItem : Entity<Guid>
{
    public OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
```

(3). 定义客户模型。

它是一个实体，用于表示客户的信息。

```csharp
public class Customer : Entity<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
}
```

(4). 定义商品模型。

它是一个实体，用于表示商品的信息。

```csharp
public class Product : Entity<Guid>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
}
```

#### 7.15 使用强类型ID

(1). 为业务模型中的Id定义值对象。

```csharp
public record CustomerId
{
    public Guid Value { get; }
}

public record OrderId
{
    public Guid Value { get; }
}

public record ProductId
{
    public Guid Value { get; }
}
```

(2). 将订单模型中的标识符类型从原始类型替换为值对象，并将聚合根的标识符类型从 `Guid` 替换为 `OrderId`。

```csharp
public class Order : Aggregate<OrderId>
{
    ...

    public CustomerId CustomerId { get; set; }
    
    ...
}
```

#### 7.16 定义领域异常

在 `Exceptions` 文件夹中定义领域异常类 `DomainException`。

```csharp
public class DomainException : Exception
{
    public DomainException(string message)
    : base($"Domain Exception: \"{message}\" throws from Domain Layer.")
    {
        
    }
}
```
#### 7.17 将客户模型改为充血模型

(1). 将客户模型实体改为充血模型。

```csharp
public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var customer = new Customer
        {
            Name = name,
            Email = email,
        };

        return customer;
    }
}
```

(2). 将客户Id值对象改为充血模型。

```csharp
public record CustomerId
{
    public Guid Value { get; }

    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (Guid.Empty == value)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new CustomerId(value);
    }
}
```

#### 7.18 定义领域事件

在 `Events` 文件夹中定义领域事件类 `OrderCreatedEvent`。

```csharp
public record OrderCreatedEvent(Order Order) : IDomainEvent;
```

#### 7.19 在订单聚合根中触发领域事件

在订单聚合根中调用领域事件 `OrderCreatedEvent`、`OrderUpdatedEvent`。

```csharp
public class Order : Aggregate<OrderId>
{
    ...

    public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
    {
        var order = new Order
        {
            Id = id,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Status = OrderStatus.Pending,
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void Add(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var orderItem = new OrderItem(Id, productId, quantity, price);
        _orderItems.Add(orderItem);
    }

    public void Remove(ProductId productId)
    {
        var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}
```

### 8. Ordering.Infrastructure 使用 EF Core 代码优先开发方式构建基础设施层

**迁移**

迁移是一种逐步更新数据库架构的方法，确保数据库架构始终与应用程序的数据模型保持同步。

当模型发生变更时，生成相应的迁移脚本，用于描述数据库中需要进行的更新操作。在 Entity Framework Core 会将当前模型与之间模型的快照进行比较，找出其差异部分，并生成相应的迁移源文件。

**代码优先模式(Code-First Approach)**

代码优先指的是先定义数据模型，然后根据模型生成数据库架构。

#### 8.1 安装 EF Core 相关 NuGet 包

在 `Ordering.Infrastructure` 项目中安装 EF Core 相关 NuGet 包。

(1). 在 Ordering.API 中安装 `Microsoft.EntityFrameworkCore.Design` 包。

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

(2). 在 Ordering.Infrastructure 中安装 `Microsoft.EntityFrameworkCore.SqlServer` 包。

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

#### 8.2 定义数据库上下文

在 `Data` 文件夹中定义数据库上下文 `ApplicationDbContext`。并应用
 `ApplyConfigurationsFromAssembly` 方法，将 `Ordering.Infrastructure.Data` 程序集
 中的所有配置类应用到模型构建器中。

```csharp
namespace Ordering.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
```

#### 8.3 定义数据库上下文配置类

在 `Configurations` 文件夹中定义数据库上下文配置类 `OrderConfiguration`。并添加复杂类型的配置。

```csharp
namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            orderId => orderId.Value,
            orderId => OrderId.Of(orderId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .IsRequired();

        builder.HasMany(x => x.OrderItems)
            .WithOne()
            .HasForeignKey(x => x.OrderId);

        builder.ComplexProperty(
            x => x.OrderName,
            nameBuilder =>
            {
                nameBuilder.Property(x => x.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
            });

        builder.ComplexProperty(
            x => x.ShippingAddress,
            addressBuilder =>
            {
                addressBuilder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(x => x.Email)
                    .HasMaxLength(50);

                addressBuilder.Property(x => x.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(x => x.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(x => x.State)
                    .HasMaxLength(50);

                addressBuilder.Property(x => x.Zipcode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

        builder.ComplexProperty(
            x => x.BillingAddress,
            addressBuilder =>
            {
                addressBuilder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(x => x.Email)
                    .HasMaxLength(50);

                addressBuilder.Property(x => x.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(x => x.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(x => x.State)
                    .HasMaxLength(50);

                addressBuilder.Property(x => x.Zipcode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

        builder.ComplexProperty(
            x => x.Payment,
            paymentBuilder =>
            {
                paymentBuilder.Property(x => x.CardName)
                    .HasMaxLength(50);

                paymentBuilder.Property(x => x.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                paymentBuilder.Property(x => x.Expiration)
                    .HasMaxLength(10);

                paymentBuilder.Property(x => x.CVV)
                    .HasMaxLength(3);

                paymentBuilder.Property(x => x.PaymentMethod);
            });

        builder.Property(x => x.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                orderStatus => orderStatus.ToString(),
                orderStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), orderStatus));

        builder.Property(x => x.TotalPrice);
    }
}
```

#### 8.4 注入数据库上下文

```csharp
namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(connectionString));
        return services;
    }
}
```

#### 8.5 生成迁移文件

(1). 在 `Ordering.Infrastructure` 项目中生成迁移文件，并将文件目录设置为 `Data\Migrations` 中。

```bash
dotnet ef migrations add InitialCreate --project .\Ordering.Infrastructure --startup-project .\Ordering.API\ --output-dir Data\Migrations
```

或简写命令

```bash
dotnet ef migrations add InitialCreate -p Ordering.Infrastructure -s Ordering.API -c ApplicationDbContext -o Data/Migrations
```

(2). 在 `Ordering.Infrastructure` 项目中应用迁移文件。

```bash
dotnet ef database update --project .\Ordering.Infrastructure --startup-project .\Ordering.API\
```

或简写命令

```bash
dotnet ef database update -p Ordering.Infrastructure -s Ordering.API -c ApplicationDbContext
```

#### 8.6 自动迁移数据库

(1). 在 `Ordering.Infrastructure` 项目中添加扩展方法，用于自动迁移数据库。

```csharp
namespace Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();
    }
}
```

#### 8.7 填充种子数据

(1). 在 `Ordering.Infrastructure` 项目中添加种子数据类。

```csharp
namespace Ordering.Infrastructure.Data.Extensions;

internal static class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "mehmet",
                "mehmet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), "Xiaomi Mi", 450)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 2, 500);
            order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order2.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 1, 650);
            order2.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}
```

(2). 在 `Ordering.Infrastructure` 项目中添加扩展方法，用于填充种子数据。

```csharp
namespace Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();

        await SeedDatabaseAsync(context);
    }

    private static async Task SeedDatabaseAsync(ApplicationDbContext context)
    {
        await SeedCustomerAsync(context);
        await SeedProductAsync(context);
        await SeedOrdersWithItemsAsync(context);
    }

    private static async Task SeedCustomerAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedProductAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedOrdersWithItemsAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
            await context.SaveChangesAsync();
        }
    }   
}
```

#### 8.8 EF Core 拦截器实现审计实体

在 Entity Framework Core 中，拦截器是一种用于在执行数据库操作之前或之后执行自定义逻辑的机制。

- `ISaveChangesInterceptor`：在调用 `SaveChanges` 或 `SaveChangeAsync` 方法时拦截，并执行自定义逻辑。
- `IQueryableInterceptor`：在查询数据库时拦截。

在保存时拦截的一个使用场景是审计(Auditing)，可用于创建独立的审计记录，对于维护实体的变更历史非常有用。

(1). 实现拦截器

在 `Interceptors` 文件夹中 创建 `AuditSaveChangesInterceptor` 类，实现 `ISaveChangesInterceptor` 接口。

审计拦截器的主要功能是在保存更改时，自动更新实体的审计字段，如创建时间、创建人、更新时间、更新人等。

```csharp
namespace Ordering.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? dbContext)
    {
        if (dbContext is null)
            return;

        foreach (var entry in dbContext.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "mehmet";
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.CreatedBy = "mehmet";
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry)
        => entry.References.Any(x =>
            x.TargetEntry != null && 
            x.TargetEntry.Metadata.IsOwned() && 
            (x.TargetEntry.State == EntityState.Added ||
            x.TargetEntry.State == EntityState.Modified));
}
```

(2). 注册拦截器

使用 `AddInterceptors` 方法注册拦截器。

```csharp
namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}
```

#### 8.9 EF Core 保存拦截器处理领域事件

在 Entity Framework Core 中，保存拦截器还可以用于处理领域事件。

**领域事件(Domain Events)**表示过去发生的一些事件，同一服务边界内属于同一领域的其他组件都需要对这些事件做出相应的反应。

领域事件是指在领域模型中发生的业务事件，它通常表示某个领域操作产生的副作用。确保同一领域内各种数据的一致性。

(1). 实现派发领域事件拦截器

```csharp
public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context is null)
            return;

        var aggregates = context.ChangeTracker
            .Entries<IAggregate>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity);

        var domainEvents = aggregates
            .SelectMany(x => x.DomainEvents)
            .ToList();

        foreach (var aggregate in aggregates)
            aggregate.ClearDomainEvents();

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
```

(2). 注册多个拦截器

可以将多个拦截器实现注册到 DI 容器中，当调用 `AddInterceptors` 方法时，从容器中获取多个拦截器实例。

```csharp
namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}
```

### 9. Ordering.Application 使用 CQRS 与 MediatR 构建应用层

- 应用 DDD、CQRS 和 整洁架构模式。
- 使用 CQRS 处理订单的CURD功能。
- 使用 MediatR 通过中介者模式来实现命令处理。
- 使用 MediatR 的 INotificationHandler 来开发领域事件处理器。
- 使用 CQRS 和 MediaR 开发订单查询系统。

#### 9.1 应用层的基本使用模式

- CQRS 模式
- 事件溯源(Event Sourcing)模式
- 结合事件溯源的CQRS架构
- 最终一致性原则

**CQRS 命令型查询与职责分离架构**

为了避免复杂的查询以及低效的连接操作，通过使用不同的数据库来分别处理读写操作。

为了处理大规模微服务架构需要处理海量数据所带来的挑战，以及各种服务使用同一数据库可能会导致的性能瓶颈。

将同时采用CQRS和事件驱动模式来提升应用程序的性能。CQRS通过分离数据的读写操作，从而最大限度地提升查询性能及系统的可扩展性。

**CQRS 读写分离**

如果我们的应用程序主要用于数据读取，而写入操作较少，那么就可以被归类为以数据读取为主的应用程序。

为了提高查询性能，读操作会从高度反规划处理(highly denormalized)的数据库中读取数据，从而避免进行耗时且重复的表连接操作以及避免锁表现象的发生。

“职责分离” 原则：应将读取数据库与写入数据库分开，分别使用两个不同的数据库。

读取数据库：使用 NoSQL 数据库
写入数据库：使用 关系型 数据库

**CQRS 读写数据库的同步机制**

- 确保数据库的读写操作保持同步
- 发布事件，该事件会从数据库中读取相关数据，并据此更新相应的读取表。
- 通过消息代理实现异步通信下的同步处理。
- 读数据库会和写数据库同步数据。
- 由于采用了 发布/订阅 模式与消息代理进行异步通信，因此某些操作在处理过程中会出现延迟。
- 但最终数据库会保持一致，这就是 最终一致性(Eventual Consistency Principle)。

**事件溯源模式(Event Sourcing Pattern)**

在大型架构中，频繁的数据库更新操作会降低数据库的性能，从而限制其可扩展性。

事件溯源模式允许将所有会影响数据库的操作都存储到事件存储数据库中，并将这些操作视为事件来处理。

与将数据的最新状态保存到数据库中的方式不同，事件溯源模式允许将所有事件按顺序保存到数据库中。

事件数据库并不是将数据覆盖到表中，而是会在数据发生任何变化时都创建一条新记录，从而形成一系列按时间顺序排列的过去事件记录。

事件列表允许用户在指定时间点重新播放这些事件，通过重新播放相关事件，它能够重新生成数据的最新状态。


**最终一致性原则(Eventual Consistency Principle)**

采取事件溯源模式的CQRS架构能够实现最终一致性。

最终一致性这种机制更适合注重系统的高可用，而非强一致性的系统。

一致性级别(Consistency Level) 共有两种；
- 严格一致性：当保存数据时，这些数据立即对客户端产生影响，并且所有客户端都能立即看到这些数据的变化。
- 最终一致性：当写入数据时，客户端需要在一定时间后才能读取到这些数据。

#### 9.2 定义数据库上下文接口

在 `Ordering.Application` 项目中定义 `IApplicationDbContext` 接口，实现依赖倒置原则，将数据库上下文的依赖从应用层解耦出来。

```csharp
namespace Ordering.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Product> Products { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
```

在 `Ordering.Infrastructure` 项目中实现 `IApplicationDbContext` 接口。

```csharp
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    ...
}
```

#### 9.3 实现 CQRS 命令

定义 `CreateOrderCommand` 命令，用于创建订单。

```csharp
namespace Ordering.Application.Orders.Command.CreateOrder;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order.OrderName)
            .NotEmpty()
            .WithMessage("OrderName is required.");

        RuleFor(x => x.Order.CustomerId)
            .NotNull()
            .WithMessage("CustomerId is required.");

        RuleFor(x => x.Order.OrderItems)
            .NotEmpty()
            .WithMessage("OrderItems are required.");
    }
}
```

实现 `CreateOrderCommandHandler` 命令处理程序，用于处理 `CreateOrderCommand` 命令。

```csharp
namespace Ordering.Application.Orders.Command.CreateOrder;

public class CreateOrderCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = CreateOrder(command.Order);

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(order.Id.Value);
    }

    private Order CreateOrder(OrderDto orderDto)
    {
        var shippingAddress = Address.Of(
            orderDto.ShippingAddress.Name,
            orderDto.ShippingAddress.Email,
            orderDto.ShippingAddress.AddressLine,
            orderDto.ShippingAddress.Country,
            orderDto.ShippingAddress.State,
            orderDto.ShippingAddress.ZipCode);

        var billingAddress = Address.Of(
            orderDto.BillingAddress.Name,
            orderDto.BillingAddress.Email,
            orderDto.BillingAddress.AddressLine,
            orderDto.BillingAddress.Country,
            orderDto.BillingAddress.State,
            orderDto.BillingAddress.ZipCode);

        var order = Order.Create(
            id: OrderId.Of(Guid.NewGuid()),
            customerId: CustomerId.Of(orderDto.CustomerId),
            orderName: OrderName.Of(orderDto.OrderName),
            shippingAddress: shippingAddress,
            billingAddress: billingAddress,
            payment: Payment.Of(
                orderDto.Payment.CardName,
                orderDto.Payment.CardNumber,
                orderDto.Payment.Expiration,
                orderDto.Payment.CVV,
                orderDto.Payment.PaymentMethod)
        );

        foreach (var orderItemDto in orderDto.OrderItems)
        {
            order.Add(ProductId.Of(orderItemDto.ProductId), orderItemDto.Quantity, orderItemDto.Price);
        }

        return order;
    }
}
```

#### 9.4 实现 CQRS 查询

(1). 在 BuildingBlocks 项目中添加 `PaginationRequest` 分页请求类与 `PaginationResult` 分页结果类。

```csharp
namespace BuildingBlocks.Pagination;

public record PaginationRequest(int PageIndex = 0, int PageSize = 10);

public class PaginationResult<TEntity>(
    int pageIndex,
    int pageSize,
    long count,
    IEnumerable<TEntity> data)
{
    public int PageIndex { get; } = pageIndex;
    public int PageSize { get; } = pageSize;
    public long Count { get; } = count;
    public IEnumerable<TEntity> Data { get; } = data;
}
```

(2). 定义 `GetOrdersQuery` 查询，用于获取订单列表，并接收分页请求参数，以及返回分页结果。

```csharp
public record GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersResult>;

public record GetOrdersResult(PaginationResult<OrderDto> Orders);
```

(3). 实现 `GetOrdersQueryHandler` 查询处理程序，用于处理 `GetOrdersQuery` 查询。

EF Core 支持使用 LINQ 方法进行分页查询，通过 `Skip` 和 `Take` 方法实现分页。

- `Skip` 跳过多少条数据。
- `Take` 获取多少条数据。

```csharp
public class GetOrdersQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(x => x.OrderItems)
            .OrderBy(x => x.OrderName)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOrdersResult(new PaginationResult<OrderDto>(
            pageIndex,
            pageSize,
            totalCount,
            orders.ToOrderDtos()
        ));
    }
}
```

在 `Ordering.Application` 项目中定义 `DependencyInjection` 类，用于注册应用层服务。

```csharp
namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        return services;
    }
}
```

### 10. Ordering.API 使用 Carter 与 REPR 模式构建API层

#### 10.1 REPR 设计模式

- 开发 API 接口，实现简单的 请求/响应 处理流程。
- `REPR` 表示 `Request-Response-Representational`，即 请求/响应/表示 模式。它简化了 `RESTful API` 的设计，将请求、响应和表示层分离，使开发人员能够更专注于业务逻辑的实现。
- `Request` 表示接口所需要的数据结构。
- `Endpoint` 即接口在接收请求时所执行的逻辑功能。
- `Response` 表示接口返回的数据结构。
 
#### 10.1 微服务编排的模式与原则

**展示层接口模式：**

- `Minimal API` 设计
- `REPR` 设计模式

**执行流程**

`Domain` -> `Infrastructure` -> `Application` -> `Presentation`

#### 10.2 定义接口

在 `Ordering.API` 项目中添加 `Endpoints` 文件夹，用于存放 `Minimal API` 接口。

```csharp
namespace Ordering.API.Endpoints;

public record CreateOrderRequest(OrderDto Order);

public record CreateOrderResponse(Guid Id);

public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateOrderCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/orders/{response.Id}", response);
            })
            .WithName("CreateOrder")
            .WithDescription("Creates Order")
            .WithSummary("Create Order")
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
```

#### 10.3 添加自定义异常处理

在 `Ordering.API` 项目中的 `DependencyInjection` 类中的 `AddApiServices` 方法中添加 `AddExceptionHandler` 方法，用于添加自定义异常处理。

```csharp
public static IServiceCollection AddApiServices(this IServiceCollection services)
{
    ...
    services.AddExceptionHandler<CustomerExceptionHandler>();
    ...
}
```

然后在 `UseApiServices` 方法中添加 `UseExceptionHandler` 中间件，用于处理自定义异常。

```csharp
public static WebApplication UseApiServices(this WebApplication app)
{
    ...
    app.UseExceptionHandler(options => { });
    ...
}
```

#### 10.4 添加健康检查

(1). 安装 `AspNetCore.HealthChecks.SqlServer` 包。

```bash
dotnet add package AspNetCore.HealthChecks.SqlServer
dotnet add package AspNetCpre.HealthChecks.UI.Client
```

(2). 添加健康检查服务

在 `Ordering.API` 项目中的 `DependencyInjection` 类中的 `AddApiServices` 方法中添加 `AddHealthChecks` 方法，用于添加健康检查。

```csharp
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        ...
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database"));
        ...
    }
```

然后在 `UseApiServices` 方法中添加 `UseHealthChecks` 中间件，用于处理健康检查。

```csharp
public static WebApplication UseApiServices(this WebApplication app)
{
    ...
    app.UseHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
    ...
}
```

### 11. Docker Compose 配置

#### 11.1 更改 Docker Compose 文件

(1). 在 `docker-compose.yml` 文件中添加服务。

```yaml
services:    
  order.db:
    image: mcr.microsoft.com/mssql/server
```

(2). 在 `docker-compose.override.yml` 文件中添加服务。

```yaml
services:        
  order.db:
    container_name: order.db
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Password@123
    restart: always
    ports:
      - "1433:1433"
```

## 十三、基于 RabbitMQ 与 MassTransit 的微服务异步通信

- 使用 RabbitMQ 消息代理服务实现异步微服务间通信
- 使用 RabbitMQ 的 发布/订阅 主题交换机(Topic Exchange)模型通信
- 使用 MassTransit 作为对 RabbitMQ 消息代理系统的抽象层

### 1. 微服务异步通信机制

- 通过使用 AMQP (Advanced Message Queuing Protocol) 协议，客户端可以通过 Kafka、RabbitMQ 等消息代理系统来发送消息。
- 消息生产者不会等待回复，由消息的订阅者异步接收，因此不存在任何一方需要等待回复的情况。
- 消息代理(Message Brokers)负责处理生产者发送的消息。如果当消费者处于不可用状态，那么代理程序可能会被设置成持续重试，直到数据成功送达为止。

#### 1.1 异步通信的优势

**可扩展性**

通过异步通信机制，我们可以更轻松地解决扩展性问题，同时能够独立地对生产者、消费者以及消息中间件系统进行扩展。根据传入消息的数量来动态调整事件总线系统的处理能力。Kubernetes的KEDA自动扩展功能也能帮助实现类似的扩展目标。 

**事件驱动型微服务**

通过异步通信，我们可以构建基于事件驱动的架构。

**重试机制**

- 当消息发送失败时，消息代理会自动重试发送消息，直到消息被成功处理或达到最大重试次数。
- 这确保了消息的可靠传递，即使在临时的网络故障或服务中断情况下也能保持消息的顺序性。

#### 1.2 异步通信的挑战

**单点故障风险(Single Point of Failure)**

- 消息代理(Message Brokers)是异步通信的关键组件，一旦消息代理发生故障，就会导致整个系统的中断。
- 为了避免单点故障风险，我们可以部署多个消息代理实例，使用负载均衡器来分发消息流量。
- 同时，我们也可以使用消息代理的高可用性机制，如主从复制或镜像队列，来确保消息代理的高可用性。

**调试(Debugging)**

异步通信带来的问题很难调试，因为很难追踪单个操作在各个服务之间的传递过程。同时，调试事件的处理流程及其携带的数据也需要耗费大量时间，而且这两项工作很难同时进行。

#### 1.3 基于 发布/订阅 模式的消息扩散与过滤机制

- `Fan-out` 是一种消息传递模式，即消息被同时并行地发送到多个目的地（也就是广播模式）。
- `Topic` 模式可以用来实现 发布者/订阅者模式，消息会立即被转发给该主题的所有订阅者。
- 每项服务均可独立运行并进行扩展，其运作方式完全解耦且属于异步处理。 
- 发布者与订阅者无需知道究竟是谁在发布或接收这些被广播的信息。 
- 向多个接收者传递相同的信息，可以使用 `Fanout` 或 `Publish/Subscribe` 消息传递模式。

#### 1.4 发布/订阅 消息模式

- 发布/订阅消息是一种异步的服务对服务通信方式。
- 任何发布到某个主题上的消息都会立即被该主题的所有订阅者收到。 
- 启用事件驱动架构，并解耦应用程序，从而提升性能、可靠性和可扩展性。
- 应用程序被分解为更小、更独立的模块，这些模块更易于开发、部署和维护。 
- 发布/订阅消息传递机制能为这些分布式应用提供即时的事件通知功能。 

### 2. 什么是 RabbitMQ？

- RabbitMQ 是一种实现高级消息队列协议(AMQP)的消息代理软件。 
- 它允许应用程序通过队列发送和接收消息来实现相互通信。
- RabbitMQ是一种消息队列系统，它能将从任意来源接收到的消息传输到另一个目标来源。 
- 类似的解决方案还包括 Apache Kafka、Msmq、Microsoft Azure Service Bus、Kestrel 以及 ActiveMQ。 
- RabbitMQ的主要组成部分包括：生产者(Producer)、队列(Queue)、消费者(Consumer)、消息(Message)、交换机(Exchange)、绑定关系(Binding)以及FIFO机制。 

#### 2.1 RabbitMQ 队列属性(Queue Properties)

- Queue Name - 定义队列的名称。
- Durable - 队列的生命周期，如果我们需要数据持久化，就必须将此属性设置为 `true`。
- Exclusive - 表示该队列是否会被其他连接一起使用。
- AutoDelete - 消费者接收到消息后是否自动删除该数据。

#### 2.2 RabbitMQ 交换机类型(Exchange Types)

- RabbitMQ提供了四种交换机类型：Direct(直接交换机)、Fanout(扇形交换机)、主题交换机(Topic Exchange)、头部交换机(Headers Exchange)。
- Direct Exhange(直接交换机)，通过直接向队列中发送消息，实现点对点的通信。
- Topic Exchange(主题交换机)，消息会根据主题转发到符合条件的队列中。
- Fanout Exchange(扇形交换机)，消息会被广播到所有绑定的队列中。
- Headers Exchange(头部交换机)，消息会根据头部信息进行路由。

### 3. 微服务 Basket 应用场景

**Basket异步操作：**

将购物车结算事件发布到RabbitMQ消息代理服务器。

**Ordering异步操作：**

- `Basket Checkout` - 使用 MassTranit 从 RabbitMQ 队列中接收购物车结算事件。
- `Order Fulfiment` - 处理订单履行相关操作（订单、发货、通知）。
- 触发 `OrderCreated` 领域事件，从而引发集成事件。

### 4. 微服务 Basket 接口定义

| 方法	  | 请求地址            | 描述                  |
| ------ | ------------------ | -------------------- |
| POST    | /basket/checkout  | 购物车结算             |

使用 `MassTransit` 从 `RabbitMQ` 中接收购物车结算事件。

### 5. 异步通信的架构风格

**事件驱动的微服务架构**

- 将事件视为不同微服务之间进行通信的主要方式。
- 提升了解耦能力(decoupling)、可扩展性(scalability)以及响应速度(responsiveness)。

**类库与NuGet包**

- `MassTransit` - 专为 .NET 平台设计的消息代理抽象层，可简化异步消息传递的实现过程。
- `MassTransit.RabbitMQ` - 专为RabbitMQ与MassTransit之间的集成而设计的功能模块。

### 6. 双重写入问题(Dual Write)

当应用程序需要同时修改两个不同系统中的数据时（比如数据库和消息队列），如果某次写入操作失败，就会导致数据不一致的情况发生。

- 数据丢失或损坏
- 没有适当的错误处理与恢复机制，问题将难以解决。
- 双重写入操作难以被检测出来，也很难被修复。

#### 6.1 双重写入的场景

1. 创建订单时将修改订单数据库中的数据。
2. 将订单创建事件发送到 Kafka 的事件总线。

#### 6.2 避免微服务中的双重写入问题

- 单体应用程序采用两阶段提交(2PC, 2 phase commit)协议。
    - 它将事务的提交过程分为两个步骤，并确保所有系统都保证ACID原则。
- 构建微服务时无法使用两阶段提交机制处理事务，因为它要求所有系统同时启动并正常运行。

**解决方案**

- `Transactional Outbox Pattern` 事务发件箱模式。
- `Change Data Capture` 也就是CDC服务。

**最佳实践**

- 在基于事件驱动的应用程序中，使用 `Apache Kafka`、`CDC`以及`Debezium`等。
- 使用像CockroachDB这样的新型数据库，它具备内置的数据变更捕获功能(CDC)。 

#### 6.3 事务发件箱模式(Transactional Outbox Pattern)

- 核心思路是在微服务数据库中创建一个`Outbox` 待发列表，用于实现事件的可靠发布。
- 当API发布事件消息时，并不会直接发送这些消息，而是将它们存储到数据库中。
- 任务会以预定义的时间间隔向消息代理系统发送事件。
- 例如订单系统中，当有新订单被添加到系统中时，将会添加订单并将 `Order_Created` 事件记录到 `Outbox` 表中，该操作会在同一个事务中完成，以确保事件能够成功保存到数据库中。
- 如果某个步骤失败，系统会依据 `ACID` 原则回滚所有之前的操作。
- 接收由独立服务写入`Outbox`表中的事件，并传输至事件总线，另一项服务则监听`Outbox`表中的记录，并将事件发布出去。

#### 6.4 微服务中的事务发件箱模式

- 微服务在其数据库中提供了一个待办事项列表表。该表会记录所有待处理的事件。 
- 将有一个CDC插件，用于读取出箱表的提交日志，并将这些事件发布到相应的队列中。 
- 该机制确保了消息能够从一个微服务可靠地传递到另一个微服务，即便触发该消息的交易发生了失败。 
- 该方法涉及将消息存储在微服务内部的本地“待发邮件”表中，该消息会在事务提交后发送给消费者。 
- Ooutbox Pattern(出站箱模式)可以确保消息能够被可靠地送达目的地，即使发送消息的微服务处于不可用状态或出现故障。 

### 7. 领域事件与集成事件(Domain Events vs Integration Events)

**Domain Events：**

- 在单一领域内发布和使用，严格限定在 微服务/领域 范围内。
- 表示在整体中发生了某件事。
- 在处理过程中同步发送，通过内存中的消息总线完成传输。

**Integration Events：**

- 用于在有限上下文或微服务环境中传达状态变化或事件发生的情况。 
- 整个系统对特定领域事件的响应方式。
- 异步方式，通过消息代理经由队列进行发送。

### 8. 分布式事务的SAGA模式

- Saga设计模式旨在分布式事务场景中保障微服务之间的数据一致性。 
- Saga能够生成一系列交易记录，这些记录会按顺序更新各个微服务，并发布相应事件来触发下一个微服务的后续操作。 
- 如果其中某个步骤失败，那么相关机制就会触发回滚操作——对相关事务进行反向处理，并向之前的微服务发送回滚事件。 
- 使用 `brokers` 或 API组合 来实现 发布/订阅。
- SAGA模式用于管理那些涉及多个微服务的长期运行事务。这些微服务实际上是由一系列独立的本地事务组成的，它们协同工作以实现端到端的业务功能。
- 在分布式系统中非常有用，因为在这种系统中需要多个微服务协同工作、协调各自的行动。 
- 确保整个交易要么成功完成，要么被恢复到初始状态。（即进行补偿性操作） 

#### 8.1 SAGA 实现的类型

1. `Choreography-based` 基于编舞式的SAGA模式。
    - 它是一种去中心化的SAGA模式，其中每个微服务都负责监听和处理事件，以触发下一个微服务的操作。
    - 每个微服务都需要知道如何处理哪些事件，以及在什么情况下触发下一个微服务。
    - 这种模式的优势在于它非常灵活，因为它不需要任何协调机制。
    - 然而，它的劣势在于它可能会变得复杂，因为每个微服务都需要知道如何处理哪些事件。
2. `Orchestration-based` 基于编排式的SAGA模式。
    - 它是一种中心化的SAGA模式，其中一个协调器微服务负责监听和处理事件，以触发下一个微服务的操作。
    - 协调器微服务需要知道如何处理哪些事件，以及在什么情况下触发下一个微服务。
    - 这种模式的优势在于它非常简单，因为它只需要一个协调器微服务。
    - 然而，它的劣势在于它可能会成为系统的单点故障，因为如果协调器微服务失败，那么整个交易就会失败。

### 9. ASP.NET 中的 Feature Flags 功能管理机制

- `Feature Flags`功能标志是一种非常强大的工具，它能让开发团队在不修改代码的情况下改变系统的运行行为。
- 它能够动态的开启或关闭各项功能，并能与现有的配置系统无缝集成。 
- `Microsoft.FeatureManagement.AspNetCore` 提供了实现功能开发的简化方法。

### 10. 微服务异步通信

#### 10.1 创建 BuildingBlocks.Messaging 类库

(1). 创建类库 `BuildingBlocks.Messaging` 用于定义集成事件。

```bash
cd .\src\BuildingBlocks\
dotnet new classlib -n BuildingBlocks.Messaging
```

将类库添加至解决方案中

```bash
cd ..\
dotnet sln add .\BuildingBlocks\BuildingBlocks.Messaging
```

#### 10.2 定义 IntegrationEvent 集成事件

- 集成事件是在微服务之间通信的事件，它们通常用于在不同的微服务之间传递状态变化或事件发生的情况。
- 集成事件通常是异步的，因为它们是通过消息队列进行传递的。
- 集成事件通常是领域事件的投影，因为它们是从领域事件中提取出来的。
- 集成事件通常是领域事件的补充，因为它们提供了更高级别的抽象，用于在微服务之间进行通信。

(1). 定义集成事件的基类

```csharp
public record IntegrationEvent
{
    public Guid Id => Guid.NewGuid();
    public DateTime OccuredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}
```

(2). 定义具体的集成事件

```csharp
public record BasketCheckoutEvent : IntegrationEvent
{
    public required string UserName { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalPrice { get; set; }

    public string Name { get; set; }
    public string Email {get;set;}
    public string AddressLine {get;set;}
    public string Country {get;set;}
    public string State {get;set;}
    public string ZipCode {get;set;}

    public string CardName {get;set;}
    public string CardNumber {get;set;}
    public string Expiration {get;set;}
    public string CVV {get;set;}
    public int PaymentMethod {get;set;}
}
```

#### 10.3 MassTransit 配置

(1). 在 `BuildingBlocks.Messaging` 项目中安装类库。

```bash
dotnet add package MassTransit.RabbitMQ
```

(2). 添加配置信息

在 `Basket.API` 项目以及 `Ordering.API` 项目中的 `appsettings.json` 文件中添加如下配置：

```json
"MessageBroker": {
    "Host": "amqp://localhost:5672",
    "UserName": "guest",
    "Password": "guest"
}
```

(3). 添加 MassTransit 配置扩展方法，用于在 ASP.NET Core 应用程序中添加 MassTransit 服务。

```csharp
namespace BuildingBlocks.Messaging.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration,
        Assembly? assembly = null)
    {
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            if (assembly != null)
                config.AddConsumers(assembly);

            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]), host =>
                {
                    host.Username(configuration["MessageBroker:UserName"]);
                    host.Password(configuration["MessageBroker:Password"]);
                });
                configurator.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
```

#### 10.4 从 微服务 Basket 项目中发布事件

(1). 在 `Basket.API` 项目中添加对 `BuildingBlocks.Messaging` 项目的引用。

```bash
dotnet add .\src\Basket\Basket.API\Basket.API.csproj reference .\src\BuildingBlocks\BuildingBlocks.Messaging\BuildingBlocks.Messaging.csproj
```

(2). 在 `Basket.API` 项目中注册 MassTransit 服务。

```csharp
builder.Services.AddMessageBroker(builder.Configuration);
```

#### 10.5 从 微服务 Basket 项目中构建结算接口

(1). 定义购物车结算请求体

```csharp
public class BasketCheckoutDto
{
    public string UserName { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalPrice { get; set; }
    
    // Shipping & Billing Address
    public string Name { get; set; }
    public string Email { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    // Payment
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public int PaymentMethod { get; set; }
}
```

(2). 实现购物车结算命令

```csharp
namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;

public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator
    : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto)
            .NotNull()
            .WithMessage("BasketCheckoutDto can't be null");

        RuleFor(x => x.BasketCheckoutDto.UserName)
            .NotEmpty()
            .WithMessage("UserName is required");
    }
}

public class CheckoutBasketHandler(
    IBasketRepository basketRepository,
    IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>

{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);
        if (basket is null)
            return new CheckoutBasketResult(false);

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await basketRepository.DeleteBasket(command.BasketCheckoutDto.UserName,cancellationToken);
        
        return new  CheckoutBasketResult(true);
    }
}
```

(3). 定义购物车结算接口

```csharp
namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);

public record CheckoutBasketResponse(bool IsSuccess);

public class CheckoutBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapPost("/basket/checkout", async (CheckoutBasketRequest request,ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                
                var result = await sender.Send(command);

                var response = result.Adapt<CheckoutBasketResponse>();
                
                return Results.Ok(response);
            })
            .WithName("CheckoutBasket")
            .WithDescription("Checkout Basket")
            .WithSummary("Checkout Basket")
            .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
```

#### 10.6 微服务 Ordering 订阅购物车结算事件

(1). 在 `Ordering.Application` 项目中添加对 `BuildingBlocks.Messaging` 项目的引用。

```bash
dotnet add .\src\Ordering\Ordering.Application\Ordering.Application.csproj reference .\src\BuildingBlocks\BuildingBlocks.Messaging\BuildingBlocks.Messaging.csproj
```

(2). 添加 MassTranit 配置

在 `Ordering.API` 项目中的 `appsettings.json` 配置文件中添加如下配置：

```json
"MessageBroker": {
    "Host": "amqp://localhost:5672",
    "UserName": "guest",
    "Password": "guest"
}
```

(3). 注册 MassTransit 服务

在 `DependencyInjection.cs` 文件中添加如下代码，用以注册 MassTransit 服务。

```csharp
namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddMessageBroker(configuration,Assembly.GetExecutingAssembly());

        return services;
    }
}
```

#### 10.7 领域事件与集成事件处理

(1). 添加领域事件处理

```csharp
namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(
    IPublishEndpoint publishEndpoint,
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        // 发布事件
        var orderCreatedIntegrationEvent = notification.Order.ToOrderDto();
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}
```

(2). 添加集成事件处理

```csharp
namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(
    ISender sender,
    ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event Handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var orderId = Guid.NewGuid();
        var addressDto = new AddressDto(message.Name, message.Email, message.AddressLine, message.Country,
            message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV,
            message.PaymentMethod);

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: OrderStatus.Pending,
            OrderItems:
            [
            ]);
        return new CreateOrderCommand(orderDto);
    }
}
```
#### 10.8 配置 Feature Flags

(1). 在 `BuildingBlocks` 项目中安装类库。

```bash
dotnet add package Microsoft.FeatureManagement.AspNetCore
```

(2). 在 `Ordering.Application` 项目中注册 `FeatureManagement` 服务。

```csharp
namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddFeatureManagement();
        services.AddMessageBroker(configuration,Assembly.GetExecutingAssembly());
        
        return services;
    }
}
```

(3). 在 `Ordering.API` 项目中的 `appsettings.json` 配置文件中添加如下配置：

```json
"FeatureManagement": {
    "OrderFulfilment": true
}
```

(4). 在领域事件处理中使用 `IFeatureManagement` 控制是否启用某个功能。

```csharp
namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(
    IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager,
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

        if (!await featureManager.IsEnabledAsync("OrderFulfilment"))
        {
            return;
        }

        // 发布事件
        var orderCreatedIntegrationEvent = notification.Order.ToOrderDto();
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}
```

### 11. Docker Compose 配置

#### 11.1 配置 docker-compose.yaml 文件

添加 `rabbitmq` 服务以及 `ordering.api` 服务。

```yaml
services:
  message.broker:
    image: rabbitmq:management

  ordering.api:
    image: ${DOCKER_REGISTRY-}ordering.api
    build:
      context: .
      dockerfile: Services/Ordering/Ordering.API/Dockerfile
```

#### 11.2 配置 docker-compose.override.yaml 文件

添加 `rabbitmq` 服务以及 `ordering.api` 服务，并修改 `basket.api` 服务配置。

```yaml
services:
  message.broker:
    container_name: message.broker
    hostname: ecommerce-rabbitmq
    environment:
      - RABBITMQ_DEFAULT_USER=guest
      - RABBITMQ_DEFAULT_PASS=guest
    restart: always
    ports:
      - "5672:5672"
      - "15672:15672"

  basket.api:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ASPNETCORE_Kestrel__Certificates__Default__Password=123456
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/home/app/.aspnet/https/localhost.pfx
      - ConnectionStrings__Database=Server=basket.db;Port=5433;Database=BasketDb;User Id=postgres;Password=postgres;Include Error Detail=true
      - ConnectionStrings__Redis=distribute.cache:6379
      - GrpcSettings__DiscountUrl=https://discount.grpc:8081
      - MessageBroker__Host=amqp://ecommerce-mq:5672
      - MessageBroker__UserName=guest
      - MessageBroker__Password=guest
    depends_on:
      - basket.db
      - distribute.cache
      - discount.grpc
      - message.broker
    ports:
      - "6001:8080"
      - "6061:8081"
    volumes:
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
  
  ordering.api:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ASPNETCORE_Kestrel__Certificates__Default__Password=123456
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/home/app/.aspnet/https/localhost.pfx
      - ConnectionStrings__Database=Server=order.db;Port=5433;Database=OrderDb;User Id=postgres;Password=postgres;Include Error Detail=true
      - MessageBroker__Host=amqp://ecommerce-mq:5672
      - MessageBroker__UserName=guest
      - MessageBroker__Password=guest
      - FeatureManagement__OrderFulfillment=false
    depends_on:
      - order.db
      - message.broker
    ports:
      - "6003:8080"
      - "6063:8081"
    volumes:
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
```

## 十四、API网关与YARP反向代理应用网关路由模式

### 1. 结合 Yarp 反向代理技术的API网关

- 网关路由模式(Gateway Routing Pattern)
- API网关模式(API Gateway Pattern)
- 前端模式的后端(BFF Backend for Frontend Pattern)
- 将 Yarp 用作反向代理服务器

#### 1.1 网关路由模式(Gateway Routing Pattern)

- 通过暴露一个单一的端点，将请求路由到多个微服务。
- 当需要在单个端点上提供多个服务，并根据请求将这些服务路由到内部后端微服务时，这种方法非常实用。 
- 客户端需要使用多个微服务，此时“网关路由”模式可以用来创建一个新的端点，该端点负责接收请求，并将这些请求路由到相应的微服务。 
- 电子商务应用可能提供以下服务：客户搜索、购物车功能、折扣优惠以及订单历史记录查询。
- 如果某个微服务发生了变更，客户端对此一无所知，也无需修改客户端的任何代码；唯一的变更仅限于路由配置的调整。
- 它将后端的微服务与客户端应用程序分离开来，从而使客户端代码保持简洁性——即便后端服务发生了变化，也无需对客户端代码进行修改。这一切都是通过API网关来实现的。
- 通过蓝绿部署(blue/green deployments)或金丝雀部署(canary deployments)方式来部署微服务API，同时为同一微服务提供多个API版本。借助网关路由机制，你可以逐步将请求引导至新的API版本。 
- 网关路由模式允许你灵活地使用不同版本的 API 来处理各类请求。 
- 如果新版本的API存在异常情况，只需进行配置调整即可快速恢复到旧版本的状态。 
- 使用应用层第7层路由机制将请求转发至内部服务。 

#### 1.2 API网关模式(API Gateway Pattern)

- API网关是客户端应用程序接入系统的唯一入口，位于客户端与多个后端服务之间。 
- API网关负责管理对内部微服务的路由请求，能够将多个微服务的请求合并为一条响应，并处理那些需要跨多个微服务处理的通用性问题。 
- 在设计基于微服务的大型复杂应用程序，且这些应用程序需要与多个客户端应用进行交互时，推荐使用该方案。 
- 类似于面向对象设计中的外观模式，但它是一种用于同步通信的分布式系统反向代理或网关路由机制。 
- 该模式提供了一个反向代理，用于将请求重定向或路由到您的内部微服务端点。 
- 充当反向代理的角色，将客户端的请求路由到后端服务，并提供身份验证、SSL加密解密以及缓存管理等通用功能。 
- 多个客户端应用程序连接到同一个API网关，这就存在单点故障的风险。 
- 如果这些客户端应用程序的数量继续增加，或者如果在APl网关中添加更多逻辑从而导致系统复杂性进一步提升，那么这种做法就违背了最佳开发实践。 
- 最佳实践是将 API Gateway 拆分为多个服务，或使用多个较小的 API Gateway——即“后端服务于前端”的架构模式。

#### 1.3 API网关模式的主要特点

**反向代理与网关路由**

使用反向代理将请求重定向到内部微服务的对应端点。对于HTTP请求，通过第7层路由机制实现重定向功能。这种机制能够将客户端应用程序与内部微服务解耦开来，同时实现网络层功能的独立性，并对内部操作进行抽象处理。 

**请求聚合与网关聚合**

将多个内部微服务整合为一次客户端请求。客户端应用程序向 API Gateway 发送一个请求，该网关会将该请求分发给多个内部微服务，随后汇总这些微服务的处理结果，并以一个响应结果的形式返回给客户端应用程序。这种方式有助于减少通信过程中的重复请求。 

**跨领域问题与枢纽功能外包**

在 API网关上实现跨功能模块的最佳实践如下：身份验证与授权、服务发现、响应缓存、重试机制、断路器功能、速率限制与节流机制、负载均衡、日志记录、跟踪功能以及IP地址白名单机制。

#### 1.4 前端模式的后端 (BFF, Backends for Frontends Pattern)

- 前端模式的后端，本质上是根据不同的前端应用来分别设置API网关的。 
- 单一的API网关会成为单一故障点。
- BFF可以创建多个API网关，并根据客户端应用程序的所属范围对它们进行分类。
- 单一且复杂的API网关可能存在风险，甚至会成为整个架构中的瓶颈。 
- 大型系统通常会根据客户端类型（如移动端、网页端和桌面端）对API网关进行分类，从而暴露出多个API网关。 
- 根据用户界面需求创建多个API网关，以确保其能最佳地满足前端环境的需求。 
- BFF模式旨在为客户端应用程序提供专门的接口，以便与内部的微服务进行交互。 

### 2. 什么是反向代理(Reverse Proxy)？

- 反向代理服务器是一种位于Web服务器前面的服务器，它将客户端的请求转发给这些Web服务器。 
- 实现了网关路由及API网关相关模式。
- 它充当客户端与提供所需资源的服务器之间的中介。客户端通过它向这些服务器发起资源请求。 
- 功能：负载均衡(Load Balancing)、卸载(Offloading)、安全(Security)

#### 2.1 微软反向代理 Yarp

- YARP是由微服务开发的一款轻量级、高度可定制的反向代理解决方案，专为 .NET 应用设计。
- 简化对不同后端服务的请求路由流程，同时提供请求转换、负载均衡等功能。

#### 2.2 微软反向代理 Yarp 功能

- 可自定义路由规则：可详细指定请求应如何被路由到后端服务。
- 跨平台：YARP基于.NET开发，因此具备跨平台能力。它可以在任何支持.NET Core的平台上运行，包括Windows、Linux和MacOS。
- 支持最新的网络协议：YARP支持包括gRPC、HTTP/2以及WebSockets在内的现代网络协议。
- 出色的性能：具备高吞吐量和低延迟的特点，非常适合需要高性能代理服务的场景。
- 健康检查：监控后端服务的运行状态，并根据需要重新调整流量。
- 现代HTTP客户端：利用.NET中的最新HTTP客户端功能来提升性能。

### 3. 网关 YarpApiGateway 技术分析

- 无需任何架构设计，只需简单配置应用设置即可实现反向代理功能。 
- 反向代理服务器是一种位于Web服务器前面的服务器，它将客户端的请求转发给这些Web服务器。 
- 基于配置的方法，用于将请求路由到不同的微服务。

**类库与Nuget包：**

- `Yarp.ReverseProxy` - 使应用程序具备反向代理功能。

### 4. YARP 微服务的 接口定义

将微服务名称作为内部`URI`的前缀，格式为 `{微服务名称}/{微服务内部URL}`

| 方法	  | YARP请求地址                 | 内部微服务请求地址      |
| ------ | --------------------------- | -------------------- |
| GET    | /category/products          | /products            |
| GET    | /category/products/{id}     | /products/{id}       |
| GET    | /category/products/category | /products/category   |
| POST   | /category/products          | /products            |
| PUT    | /category/products/{id}     | /products/{id}       |
| DELETE | /category/products/{id}     | /products/{id}       |

### 5. 网关 YarpApiGateway 项目创建

#### 5.1 创建项目结构

(1). 创建 YARP 项目

```bash
dotnet new web -n YarpApiGateway
```

(2). 将 YARP 项目添加到解决方案中

```bash
dotnet sln add ".\ApiGateways\YarpApiGateway"
```

#### 5.2 安装 Yarp 类库

(1). 在 `YarpApiGateway` 项目中安装 `Yarp.ReverseProxy` 类库

```bash
dotnet add package Yarp.ReverseProxy
```

(2). 在 `YarpApiGateway` 项目中注册 Yarp 服务

```csharp
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
```

(3). 在 `YarpApiGateway` 项目中配置 Yarp 路由

```csharp
app.MapReverseProxy();
```

#### 5.3 配置 Yarp 路由

(1). 在 `YarpApiGateway` 项目中的 `appsettings.json` 文件中添加 `Yarp` 配置。

定义各微服务的路由，将 `/{微服务名称}/{**catch-all}` 路由到 `{微服务名称}-cluster` 集群。

```json
{
  "ReverseProxy": {
    "Routes": {
      "catalog-route": {
        "ClusterId": "catalog-cluster",
        "Match": {
          "Path": "/catalog-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      },
      "basket-route": {
        "ClusterId": "basket-cluster",
        "Match": {
          "Path": "/basket-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      },
      "ordering-route": {
        "ClusterId": "ordering-cluster",
        "Match": {
          "Path": "/ordering-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      }
    },
    "Clusters": {
      "catalog-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://localhost:6000/"
          }
        }
      },
      "basket-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://localhost:6001/"
          }
        }
      },
      "ordering-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://localhost:6002/"
          }
        }
      }
    }
  }
}
```

#### 5.4 配置 Yarp 速率限制

(1). 在 `YarpApiGateway` 项目中注册速率限制服务。

使用固定窗口速率限制，窗口大小为 10 秒，允许 5 个请求。

```csharp
builder.Services.AddRateLimiter(rateLimitOptions =>
{
    rateLimitOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});
```

(2). 启用速率限制中间件

```csharp
app.UseRateLimiter();
```

(3). 在 `YarpApiGateway` 项目中配置速率限制策略

将 `ordering-route` 路由添加速率限制策略 `fixed`。

```json
{
  "ReverseProxy": {
    "Routes": {
      "ordering-route": {
        "ClusterId": "ordering-cluster",
        "RateLimiterPolicy": "fixed",
        "Match": {
          "Path": "/ordering-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      }
    }
  }
}
```

### 6. 配置文件的环境配置

通过环境变量 `ASPNETCORE_ENVIRONMENT` 来指定环境所使用的配置文件。

- `appsettings.json` 生产环境
- `appsettings.Test.json` 测试环境
- `appsettings.Development.json` 开发环境

#### 6.1 配置生产环境

将微服务地址配置为 `Docker Compose` 中定义的服务名称。

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ReverseProxy": {
    "Routes": {
      "catalog-route": {
        "ClusterId": "catalog-cluster",
        "Match": {
          "Path": "/catalog-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      },
      "basket-route": {
        "ClusterId": "basket-cluster",
        "Match": {
          "Path": "/basket-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      },
      "ordering-route": {
        "ClusterId": "ordering-cluster",
        "RateLimiterPolicy": "fixed",
        "Match": {
          "Path": "/ordering-service/{**catch-all}"
        },
        "Transforms": [
          {
            "PathPattern": "{**catch-all}"
          }
        ]
      }
    },
    "Clusters": {
      "catalog-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://catalog.api:8080/"
          }
        }
      },
      "basket-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://basket.api:8080/"
          }
        }
      },
      "ordering-cluster": {
        "Destinations": {
          "destination1": {
            "Address": "http://ordering.api:8080/"
          }
        }
      }
    }
  }
}
```


### 7. Docker 容器化与编排

#### 7.1 Docker 容器化

(1). 在 `YarpApiGateway` 项目中添加 Dockerfile 文件

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiGateways/YarpApiGateway/YarpApiGateway.csproj", "ApiGateways/YarpApiGateway/"]
RUN dotnet restore "ApiGateways/YarpApiGateway/YarpApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateways/YarpApiGateway"
RUN dotnet build "./YarpApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./YarpApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YarpApiGateway.dll"]
```

#### 7.2 配置 Docker Compose

(1). 在 `docker-compose.yml` 文件中添加 `YarpApiGateway` 服务。

```yaml
services:
  yarp.api.gateway:
    image: ${DOCKER_REGISTRY-}yarp.api.gateway
    build:
      context: .
      dockerfile: ApiGateways/YarpApiGateway/Dockerfile
```

(2). 在 `docker-compose.override.yml` 文件中添加 `YarpApiGateway` 服务的端口映射。

```yaml
services:        
  yarp.api.gateway:
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ASPNETCORE_Kestrel__Certificates__Default__Password=123456
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/home/app/.aspnet/https/localhost.pfx
    depends_on:
      - catalog.api
      - basket.api
      - ordering.api
    ports:
      - "6004:8080"
      - "6064:8081"
    volumes:
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
```

## 十五、使用 Refit 和 HttpClientFactory 库的购物网站

### 1. 开发购物网站的步骤

1. WebUI购物应用微服务

- 使用Razor Pages创建一个ASP.NET Web应用程序。
- 该应用程序将采用Bootstrap 4进行样式设计。
- 同时会使用ASP.NET Core的Razor相关工具，包括视图组件、部分视图、标签辅助程序以及模型绑定功能。 

2. 数据模型

- 定义目录模型、购物车模型以及订单模型。  
- 这些模型将用于与 YarpApiGateway 端点进行交互。 

3. Refit HttpClientFactory 库

- 使用 Refit，这是一个自动提供类型安全的 REST 开发库。  
- 利用 Refit 开发 ICatalogService、IBasketService 以及 IOrderingService 等接口。

4. Razor Pages 开发

- 首页、购物车、产品、产品详情、订单、结算 等相关页面的HTML以及C#代码。

5. 容器化与编排技术(Containerization and Orchestration)

- 在 Docker Compose 环境中运行 `Shopping.Web` 项目。

### 2. 带有 Refit 的购物网站客户端

- 基于 Bootstrap 4 主题开发 Razor 页面。
- ASP.NET Core Razor 工具：视图组件、部分视图、标签辅助程序、模型绑定与验证功能
- 使用 Refit HttpClientFactory 来调用 YarpApiGateway 接口。

### 3. 购物网站 Shopping.Web 技术分析

- 表示层(Presentation Layer)：使用 cshtml 和 razor 技术开发页面。
- 业务层(Business Layer)：调用 YarpApiGateway 的服务类。
- 数据层(Data Layer)：YarpApiGateway 用于调用下游微服务。

### 4. 购物网站 Shopping.Web 项目创建

#### 4.1 创建项目结构

(1). 创建 Razor 项目

```bash
dotnet new razor -n Shopping.Web
```

(2). 将 YARP 项目添加到解决方案中

```bash
dotnet sln add ".\WebApps\Shopping.Web"
```

#### 4.2 安装 Refit 库

在 `Shopping.Web` 项目中安装 Refit 库。

```bash
dotnet add package Refit.HttpClientFactory
``` 

#### 4.3 配置服务地址

在 `Shopping.Web` 项目的 `appsettings.json` 文件中添加服务地址配置。

```json
{
  "ApiSettings": {
    "GatewayAddress": "https://localhost:6064"
  }
}
```

#### 4.4 配置 Refit 客户端

在 `Shopping.Web` 项目的 `Program.cs` 文件中配置 Refit 客户端。

```csharp
builder.Services.AddRefitClient<ICatalogService>()
    .ConfigureHttpClient(x =>
    {
        x.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
    });

builder.Services.AddRefitClient<IBasketService>()
    .ConfigureHttpClient(x =>
    {
        x.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
    });

builder.Services.AddRefitClient<IOrderingService>()
    .ConfigureHttpClient(x =>
    {
        x.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
    });
```

### 5. 购物网站 Shopping.Web 页面开发

(1). 创建 `Index.cshtml` 页面

```html
@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<hr />

<div class="container">
    <div class="row">
        <div class="col">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="~/images/banner/banner1.png" alt="First slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="~/images/banner/banner2.png" alt="Second slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="~/images/banner/banner3.png" alt="Second slide">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>

        <partial name="_TopProductPartial" model="Model.ProductList.FirstOrDefault()" />       

    </div>
</div>

<div class="container mt-3">
    <div class="row">
        <div class="col-sm">
            <div class="card">
                <div class="card-header bg-primary text-white text-uppercase">
                    <i class="fas fa-star"></i> Last products
                </div>
                <div class="card-body">
                    <div class="row">

                        @foreach (var product in Model.ProductList.Take(4))
                        {
                            <div class="col-sm">
                                <partial name="_ProductItemPartial" model="@product" />
                            </div>
                        }

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="container mt-3 mb-4">
    <div class="row">
        <div class="col-sm">
            <div class="card">
                <div class="card-header bg-primary text-white text-uppercase">
                    <i class="fas fa-trophy"></i> Best products
                </div>
                <div class="card-body">
                    <div class="row">
                        
                            @foreach (var product in Model.ProductList.TakeLast(4))
                            {
                                <div class="col-sm">
                                    <partial name="_ProductItemPartial" model="@product" />
                                </div>
                            }
                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
```

(2). 实现 `Index.cshtml.cs` 页面模型，添加 `OnGetAsync` 方法，用于获取产品列表。

```csharp
namespace Shopping.Web.Pages
{
    public class IndexModel(
        ICatalogService catalogService,
        IBasketService basketService,
        ILogger<IndexModel> logger) : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } =
            new List<ProductModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Index page visited.");

            var result = await catalogService.GetProducts();
            ProductList = result.Products;
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked.");

            var productResponse = await catalogService.GetProductById(productId);

            var basket = await basketService.LoadUserBasket();

            basket.Items.Add(new ShoppingCartItemModel
            {
                ProductId = productId,
                ProductName = productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity = 1,
                Color = "Black",
            });

            await basketService.StoreBasket(new StoreBasketRequest(basket));
            return RedirectToPage("Cart");
        }
    }
}
```

### 6. Docker 容器化与编排

#### 6.1 Docker 容器化

(1). 在 Catalog.API 项目中添加 Dockerfile 文件

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApps/Shopping.Web/Shopping.Web.csproj", "WebApps/Shopping.Web/"]
RUN dotnet restore "WebApps/Shopping.Web/Shopping.Web.csproj"
COPY . .
WORKDIR "/src/WebApps/Shopping.Web"
RUN dotnet build "./Shopping.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Shopping.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Web.dll"]
```

#### 6.2 Docker Compose 配置

(1). 在 `docker-compose.yaml` 文件中添加 Shopping.Web 服务

```yaml
services:
  shopping.web:
    image: ${DOCKER_REGISTRY-}shopping.web
    build:
      context: .
      dockerfile: WebApps/Shopping.Web/Dockerfile
```

(2). 在 `docker-compose.override.yaml` 文件中添加 Shopping.Web 服务的端口映射

```yaml
services:  
  shopping.web:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ASPNETCORE_Kestrel__Certificates__Default__Password=123456
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/home/app/.aspnet/https/localhost.pfx
      - ApiSettings__GatewayAddress=http://yarp.api.gateway:8080
    depends_on:
      - yarp.api.gateway
    ports:
      - "6005:8080"
      - "6065:8081"
    volumes:
      - ${USERPROFILE}/.aspnet/Https:/home/app/.aspnet/https:ro
```