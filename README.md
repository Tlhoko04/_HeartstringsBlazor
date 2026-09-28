# Heartstrings: Cozy Bonds & Friendship Haven

A full-stack, component-based **ASP.NET Core Blazor Web App** (.NET 8) demonstrating all **7 Gang-of-Four (GoF) Structural Design Patterns** using a cozy life-sim, follower community, and friendship-building domain.

---

## Overview

Heartstrings demonstrates how to build modular, decoupled web architectures by mapping classic structural design patterns to interactive social interactions (warm hugs, shared keepsake cards, slumber parties, and friendship circles). The project features a pastel aesthetic with real-time C# event telemetry.

---

##  Design Patterns Implemented

| Pattern | Domain Implementation | Key Classes / Interfaces |
| :--- | :--- | :--- |
| **Adapter** | Converts vintage handwritten paper diaries into modern live social feed events. | `IFriendshipMomentScanner`, `DiaryMemoryAdapter`, `HandwrittenDiaryNote` |
| **Bridge** | Decouples friendship gestures from emotional vibe delivery styles so both vary independently. | `FriendlyGesture`, `WarmHugGesture`, `IBondVibe`, `GentleComfortVibe` |
| **Composite** | Structures friend networks and community groups into a unified hierarchical tree. | `ISocialUnit`, `CloseFriend` (Leaf), `FriendshipCircle` (Composite) |
| **Decorator** | Dynamically layers keepsake attachments onto friendship cards to increase bond affinity. | `IFriendshipCard`, `KeepsakeDecorator`, `HandmadeBraceletKeepsake`, `MemoryLocketKeepsake` |
| **Facade** | Provides a unified, single-call interface to orchestrate lighting, lofi music, and sweet treats. | `SlumberPartyGatheringFacade`, `CozyFairyLighting`, `AcousticMusicPlaylist` |
| **Flyweight** | Caches shared heart particle sprite profiles so thousands of floating particles consume minimal RAM. | `HeartParticleFactory`, `HeartParticleType`, `ActiveHeartParticle` |
| **Proxy** | Enforces a 500+ follower bond affinity gate before lazy-loading the private memory scrapbook. | `ISecretSanctuary`, `BestiesSanctuaryProxy`, `RealBestiesSanctuary` |

---

## Tech Stack 

- **Framework:** ASP.NET Core Blazor (.NET 8.0)
- **Language:** C#
- **Frontend / Styling:** Blazor Razor Components, CSS3 Flexbox/Grid, Glassmorphism & Soft Pastel Theme
- **Architecture:** Separation of Concerns (Domain logic isolated in `FriendshipPatterns.cs`, UI in `Home.razor`)

---

## Getting Started

### Prerequisites
- Visual Studio 2022 (with the **ASP.NET and web development** workload) or the .NET 8.0 SDK.

### Running the App
1. Clone this repository:
   ```bash
   git clone https://github.com/Tlhoko04/HeartstringsBlazor.git
