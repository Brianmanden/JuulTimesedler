---
name: solution-models
description: Specialized expertise for managing architectural consistency across the JuulTimesedler solution. Use this skill when modifying 'SharedModels', designing DTOs, updating enums, or ensuring structural alignment between frontend and backend.
---

# Solution Architect

## Overview
This skill focuses on the structural backbone of the solution. It ensures that data contracts, domain models, and architectural patterns remain consistent across the frontend (`JuulTimesedler_FE`), backend (`JuulTimesedler_BE`), and shared layers.

## Core Tasks

### 1. Data Contract Design (DTOs)
When designing or updating DTOs in `SharedModels/DTOs/`:
- **Purpose-Built:** Prefer separate DTOs for different operations (e.g., `GetProjectDTO` vs `PutTimesheetDTO`) to minimize payload and clarify intent.
- **Validation:** Use `System.ComponentModel.DataAnnotations` to enforce consistency and enable validation on both FE and BE.
- **Serialization:** Ensure properties are compatible with `System.Text.Json` or other serialization libraries used.

### 2. Domain Models & Enums
When managing shared entities and constants:
- **Enums:** Use enums (e.g., `WeekDays`) to represent static sets of values, ensuring shared logic across the stack.
- **Models:** Maintain a clear distinction between shared models and Umbraco-specific backend models.

### 3. Cross-Project Consistency
Ensure structural alignment:
- **Dependency Management:** Maintain the `SharedModels` project as a core dependency for both FE and BE.
- **Namespace Consistency:** Follow the `SharedModels.[Category]` namespace pattern.
- **Breaking Changes:** Proactively identify and communicate changes that require updates in both FE and BE.

### 4. Serialization & Type Safety
Optimize data transfer:
- **JSON Configuration:** Align JSON serialization settings (e.g., naming policies) between the Umbraco API and Blazor client.
- **Type Compatibility:** Use types that bridge well across projects (e.g., avoid backend-only types in shared DTOs).

## Resources
- **references/shared-architecture.md**: Detailed guidelines for DTO design and shared structural patterns.
- **references/serialization-guidelines.md**: Best practices for JSON serialization and data transfer.
