# PRex
A *very* simple Azure DevOps Pull Request parser and desktop notifier for Windows.

Use at your own risk.
# Getting Started
1. Issue yourself a Personal Access Token (PAT) directly from your Azure DevOps account - this app only requires the **Code - READ** scope. I do not recommend granting your token full access or any other additional tokens. **KEEP THIS TOKEN SAFE - I DO NOT ACCEPT ANY RESPONSIBILITY FOR MISPLACED TOKENS**.
2. Copy and paste your token into the app.config file in the `appSettings` section, key `PAT`.
3. In the same app.config sections, specify your *Organisation* (in the `Org` setting) and your *Active Project* (in the `ActiveProject` setting). 