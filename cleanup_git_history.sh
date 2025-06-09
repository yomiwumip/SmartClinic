#!/bin/bash

# === CONFIGURATION ===
SECRET_PATH="SmartClinic/src/MyHealth.Web/node_modules/public-encrypt/test/test_rsa_privkey.pem"
BRANCH="main"

echo "🚨 Starting Git history cleanup to remove sensitive file: $SECRET_PATH"

# Step 1: Check git-filter-repo
if ! command -v git-filter-repo &> /dev/null
then
    echo "❌ 'git-filter-repo' not found. Please install it first:"
    echo "👉 pip install git-filter-repo"
    exit 1
fi

# Step 2: Remove the file from history
echo "🧹 Cleaning Git history..."
git filter-repo --path "$SECRET_PATH" --invert-paths

# Step 3: Add to .gitignore
echo "🔒 Updating .gitignore..."
cat <<EOL >> .gitignore

# Block secrets and sensitive files
*.pem
*.key
*.env
node_modules/
EOL

git add .gitignore
git commit -m "Update .gitignore to prevent secrets and node_modules from being committed"

# Step 4: Push to GitHub
echo "🚀 Force pushing to remote branch '$BRANCH'..."
git push origin "$BRANCH" --force

echo "✅ Cleanup complete. Your GitHub repo is now secret-free and protected!"
