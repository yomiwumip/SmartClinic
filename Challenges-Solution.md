## 🚧 git 

This section documents the issues encountered while setting up and migrating the **SmartClinic** project to a new GitHub repository, as well as the steps taken to resolve them.

---

### ❗️1. Secret Key Blocking Push by GitHub

**Problem:**
GitHub detected a private SSH key (`test_rsa_privkey.pem`) accidentally committed inside the project (specifically under `node_modules/public-encrypt/test/`). GitHub blocked the push due to [push protection](https://docs.github.com/en/code-security/secret-scanning/push-protection).

**Solution:**
- Identified the secret using:
  ```bash
  git rev-list --objects --all | grep <blob-id>
  ```
- Located the secret file path:  
  `SmartClinic/src/MyHealth.Web/node_modules/public-encrypt/test/test_rsa_privkey.pem`
- Installed `git-filter-repo`:
  ```bash
  pip install git-filter-repo
  ```
- Created and ran a cleanup script to remove all traces of the file from Git history.
- Created a fresh clone of the repository and copied over the cleaned source (excluding the old `.git` folder).
- Verified `.gitignore` excluded `*.pem` and `node_modules`.
- Re-initialized Git, committed, and pushed clean history successfully.

---

### ❗️2. Git Credential Issues

**Problem:**
Git raised this error when attempting to push:
```
remote: Invalid username or password.
fatal: Authentication failed
```

**Solution:**
- Used **GitHub Personal Access Token (PAT)** instead of password when prompted.
- Recommended to set up **GitHub CLI or Git Credential Manager Core** for persistent authentication:
  ```bash
  git config --global credential.helper manager-core
  ```

---

### ❗️3. `git-filter-repo` Refused Cleanup

**Problem:**
Attempting to clean history with `git-filter-repo` returned:
```
Refusing to destructively overwrite repo history since this does not look like a fresh clone.
```

**Solution:**
- Cloned a fresh copy of the repository using:
  ```bash
  git clone https://github.com/username/SmartClinic.git
  ```
- Then reran the cleanup process in the clean repo.

---

### ❗️4. Large Push Fails Secret Scan

**Problem:**
GitHub secret scan flagged the push as too large to complete scanning in time.

**Solution:**
- Reduced the repository size by removing unnecessary files.
- Committed and pushed in smaller batches if needed.
- Confirmed `.gitignore` included all sensitive or unnecessary files.

---

### ✅ Final State

- ✅ Clean repo successfully pushed to GitHub.
- ✅ Secret files removed permanently from history.
- ✅ `.gitignore` properly configured.
- ✅ Project ready for CI/CD integration with Azure DevOps.

---

### 📁 .gitignore Additions for Future Safety

To avoid pushing unnecessary or risky files again, the following were added to `.gitignore`:

```gitignore
*.pem
node_modules/
.vs/
obj/
bin/
```

---

### 🧠 Recommendation

If working with sensitive data:
- Never commit secrets to Git
- Use environment variables and secret managers
- Enable GitHub's Push Protection on all branches
