# Specialized Project Agents

This repository uses **Agent Skills** to provide specialized expertise across the different layers of the `JuulTimesedler` solution. These agents can be activated on-demand to handle complex domain-specific tasks.

## Available Agents

### 1. Umbraco Backend Expert (`umbraco-expert`)
- **Domain:** `JuulTimesedler_BE`, Controllers, Services, and Umbraco configuration.
- **Focus:** CMS content modeling, API development, and backend business logic.
- **Location:** `.agents/skills/umbraco-expert/SKILL.md`

### 2. Blazor Frontend Specialist (`blazor-ui`)
- **Domain:** `JuulTimesedler_FE`, Razor components, and CSS.
- **Focus:** UI/UX consistency, Blazor ViewModel patterns, and interactive components.
- **Location:** `.agents/skills/blazor-ui/SKILL.md`

### 3. Solution Architect (`solution-models`)
- **Domain:** `SharedModels`, DTOs, and project-wide architecture.
- **Focus:** Data consistency across FE/BE, serialization, and architectural standards.
- **Location:** `.agents/skills/solution-models/SKILL.md`

## Usage

These agents are activated automatically when their expertise is needed, or can be manually loaded using the `/skills` command.
