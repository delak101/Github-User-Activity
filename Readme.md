note: this project is inspired by [roadmap.sh](roadmap.sh) here's a link to the project https://roadmap.sh/projects/github-user-activity
# GitHub User Activity

[GitHub User Activity](https://github.com/delak101/Github-User-Activity) is a C# console application that fetches and displays the recent activity of a GitHub user using the GitHub API.

## Prerequisites

- .NET SDK 6.0 or later
- A GitHub account

## Setup

1. Clone the repository:
    ```sh
    git clone https://github.com/delak101/GitHubUserActivity.git
    cd GitHubUserActivity
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

## Build

To build the project, run:
```sh
dotnet build
```

## Run

To run the application, use the following command:
```sh
dotnet run --project GitHubUserActivity <GitHubUsername>
```
Replace `<GitHubUsername>` with the GitHub username you want to fetch the activity for.

## Example

```sh
dotnet run --project GitHubUserActivity octocat
```

## Code Overview

The main logic of the application is implemented in the [`Program.cs`](GitHubUserActivity/Program.cs) file. It performs the following steps:

1. Constructs the GitHub API URL for the specified user.
2. Sends an HTTP GET request to the GitHub API.
3. Parses the JSON response to extract event details.
4. Displays the recent activity of the user in the console.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
```

Make sure to replace `https://github.com/yourusername/GitHubUserActivity.git` with the actual URL of your repository.
```
