# learn-dotnet-eshop-microservices

.NET 9 微服务 DDD、CQRS、垂直切片架构/整洁架构。

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
- ASP.NET Core Minimal APIs 以及 .NET 9 和 C# 12 的最新特性
- 基于功能文件夹 ( Feature Folders ) 和 垂直切片架构 ( Vertical Slice Architecture ) 实现
- 基于 MediatR 实现 CQRS 模式
- 基于 MediatR 与 FluentValidation 的 CQRS 验证管道行为 ( Validation Pipeline Behaviours )
- 使用 Marten 库在 PostgreSQL 上实现 .NET 事务型文档数据库
- 使用 Carter 库定义 Minimal API 接口
- 横切关注点 ( 关注点分离 )：日志记录、全局异常处理和健康检查
- 用于在 Docker 环境中运行多容器的 Dockerfile 和 docker-compose 文件

**购物车 ( Basket )**
- 遵循 RESTful API 原则的 ASP.NET 9 Web API 应用，实现 CRUD 操作
- 使用 Redis 作为购物车数据库的分布式缓存
- 实现代理 ( Proxy )、装饰器 ( Decorator )、和缓存旁路 ( Cache-aside ) 设计模式
- 调用折扣 ( Discount ) gRPC 服务、实现服务间同步通信以计算商品最终架构
- 使用 MassTransit 和 RabbitMQ 发布 购物车结算 消息队列

**折扣 ( Discount )**
- ASP.NET 9 gRPC 服务端应用
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

- 掌握使用设计模式、原则和最佳实践开发 .NET 9 微服务的核心技能，成为该领域的专家。
- 面向软件开发人员和架构师设计。
- 运用云原生微服务的设计模式与原则，落实行业最佳实践。
- 深入掌握 C# 12、.NET 9 和 ASP.NET 9 的最新特性，例如 Minimal API、主构造函数等。
- 全面理解 .NET 9 微服务架构，具备独立设计、开发和部署微服务应用的能力。

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

## 三、.NET 9/C# 12

### 1. .NET 9 新特性

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
- ASP.NET 9 的 Minimal API和路由机制：ASP.NET 9 的 Minimal API 简化了接口定义，提供轻量级的语法用于路由和处理HTTP请求。
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

#### 4.4 安装 Mapster 类库

(1). 在 BuildingBlocks 项目中安装 Mapster 类库

```bash
dotnet add package Mapster
```

#### 4.3 安装 Carter 类库

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

#### 4.2 封装CQRS

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

#### 4.3 定义 Carter 接口

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

#### 4.4 添加全局引用

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