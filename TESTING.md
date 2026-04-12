# Testing Instructions

To verify the fixes and improvements, follow these steps:

## Prerequisites
- .NET 9.0 SDK or later (if using a later version, you may need to update the `TargetFramework` in the `.csproj` files).

## Running the Application
1. **Start the Backend:**
   ```bash
   cd JuulTimesedler_BE
   dotnet run
   ```
   The backend should be available at `https://localhost:44371`.

2. **Start the Frontend:**
   ```bash
   cd JuulTimesedler_FE
   dotnet run
   ```
   The frontend should be available at `http://localhost:5256`.

## Verification Steps
1. **Saturday Data Fix:**
   - Open the frontend in your browser.
   - Navigate through the week tabs.
   - Verify that **Saturday** (Sat) is correctly displayed and has its own data, instead of a duplicate Sunday.
2. **MudBlazor Components:**
   - Open the browser's developer console (F12).
   - Ensure there are no errors or warnings related to `MudTreeView` or `MudButton` attributes.
   - Verify that the Task TreeView allows multiple selections correctly.
3. **Form Submission:**
   - Select a project and some tasks.
   - Add a comment.
   - Click the **Send** button.
   - Verify that the status message changes to "Sending..." and then to **"Success!"**.
4. **Configuration:**
   - You can now change the backend API URL in `JuulTimesedler_FE/wwwroot/appsettings.json` without recompiling the code.
