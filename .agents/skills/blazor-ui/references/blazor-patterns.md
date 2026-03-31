# Blazor UI Patterns for JuulTimesedler

## 1. Reusable Component with Parameters
A standard pattern for child components that communicate with parents.

```razor
<!-- ChildComponent.razor -->
<div class="card @Class">
    <h3>@Title</h3>
    @ChildContent
    <button class="btn btn-primary" @onclick="HandleClick">@ButtonText</button>
</div>

@code {
    [Parameter] public string Title { get; set; } = "Default Title";
    [Parameter] public string ButtonText { get; set; } = "Click Me";
    [Parameter] public string? Class { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public EventCallback OnAction { get; set; }

    private async Task HandleClick() => await OnAction.InvokeAsync();
}
```

## 2. Using ViewModels (MVVM-ish)
Injecting a ViewModel to separate logic from the `.razor` file.

```razor
<!-- Index.razor -->
@page "/"
@inject IndexViewModel ViewModel

@foreach (var project in ViewModel.Projects) {
    <ProjectCard Project="project" />
}

@code {
    protected override async Task OnInitializedAsync() {
        await ViewModel.LoadDataAsync();
    }
}
```

## 3. Form Validation with DTOs
Using `EditForm` with shared DTOs and DataAnnotation validation.

```razor
<EditForm Model="@timesheetDto" OnValidSubmit="HandleSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <InputNumber @bind-Value="timesheetDto.Hours" class="form-control" />
    <button type="submit">Save</button>
</EditForm>

@code {
    private PutTimesheetDTO timesheetDto = new();
    private async Task HandleSubmit() {
        // ... logic
    }
}
```

## 4. Conditional Rendering & Loading States
Providing visual feedback during async operations.

```razor
@if (isLoading) {
    <div class="spinner">Loading...</div>
} else {
    <TaskList Tasks="tasks" />
}
```
