# National Parks App
### IT3048 Final Project

A cross-platform mobile application built with **.NET MAUI** that lets tri-state area users explore state and national parks across Ohio, Indiana, and Kentucky using the [National Park Service (NPS) public API](https://www.nps.gov/subjects/developer/api.htm). Users can search for parks, view detailed information, and maintain a personal digital passport.

---

## Goals

- **Discover parks** — Search for national parks and public lands by name or keyword, filtered by one or more states (OH, IN, KY).
- **View park details** — See full descriptions, photos, addresses, and designations for any park returned by the NPS API.
- **Maintain a passport** — Track which national parks you've visited through a visual stamp-book interface; stamps reveal themselves when a park is marked as visited from the details page.


---

## Project Structure

```
IT3048FinalNationalParksApp/
├── MainApp/
│   ├── SearchPage.xaml / .cs          # Park search UI
│   ├── PassportPage.xaml / .cs        # Visited parks stamp book
│   ├── ParkDetailsPage.xaml / .cs     # Full park detail view
│   └── AppShell.xaml / .cs            # Navigation shell & routes
├── Views/
│   ├── SearchViewModel.cs             # Search logic & state
│   ├── PassportViewModel.cs           # Passport stamp collection
│   ├── ParkDetailsViewModel.cs        # Details page logic
│   ├── ParkNavigationContext.cs       # Static navigation payload holder
│   └── VisitedParksStore.cs           # Singleton visited-parks state
├── Models/
│   ├── Park.cs                        # NPS API response model
│   └── Parks.cs                       # Collection wrapper
└── Services/
    ├── APIService.cs                  # NPS API calls
    ├── DatabaseService.cs             # Local SQLite persistence
    └── ParksVisitedService.cs         # Visited-parks data access
```

---

## Prerequisites

| Tool | Version |
|---|---|
| [Visual Studio 2022](https://visualstudio.microsoft.com/) | 17.8 or later |
| .NET MAUI workload | Included with VS 2022 |
| .NET SDK | 8.0 |
| Android SDK | Installed via Visual Studio |
| NPS API Key | Free — see below |

---

## Getting an NPS API Key

1. Go to [https://www.nps.gov/subjects/developer/get-started.htm](https://www.nps.gov/subjects/developer/get-started.htm)
2. Fill out a short registration form to receive a key instantly via email.
3. Open `Services/APIService.cs` and replace the placeholder key value:

```csharp
private const string ApiKey = "YOUR_API_KEY_HERE";
```

---

## Building the App

1. **Clone or download** the repository and open `IT3048FinalNationalParksApp.sln` in Visual Studio 2022.

2. **Restore NuGet packages** — Visual Studio does this automatically on first open, or you can run:
   ```
   dotnet restore
   ```

3. **Set your target platform** using the toolbar dropdown (e.g., `net8.0-android`, `net9.0-windows10.0.19041.0`).

4. **Build the solution:**
   ```
   dotnet build
   ```

---

## Running the App

- Start an Android emulator from the **Android Device Manager** (Tools → Android → Android Device Manager), or connect a physical device with USB debugging enabled. We recommend the Google Nexus emulator for best compatibility.
- Select the `net8.0-android` target in the toolbar.
- Press **F5** to build and deploy to the emulator or device.

---

## Features at a Glance

| Feature | Description |
|---|---|
| State filter | Toggle OH, IN, and/or KY before searching |
| Park search | Queries the NPS API and deduplicates results across states |
| Details page | Photo, full description, address, and designation |
| Mark as Visited | Button on the details page updates the passport in real time |
| Passport | Visual stamp grid; unvisited parks show as mystery stamps |
| Tap to explore | Stamps on the passport also open the details page |
