#!/usr/bin/env bash
set -e

REPO_URL="https://github.com/resulersurr/TURTAKIP.git"

# Çalışma dizinini proje dizinine ayarla (script'in bulunduğu dizin)
cd "$(dirname "$0")"

# Git başlat (varsa atla)
if [ ! -d .git ]; then
  git init
fi

# Tüm dosyaları ekle
git add .

# Eğer commit yapılacak değişiklik yoksa bunu atla
if git diff --cached --quiet; then
  echo "No staged changes to commit."
else
  git commit -m "Initial commit"
fi

# Ana dalı main yap
git branch -M main

# Eski origin'i kaldır ve yeni origin ekle
git remote remove origin 2>/dev/null || true
git remote add origin "$REPO_URL"

# Push (HTTPS olduğu için kullanıcı adı + PAT istenebilir)
git push -u origin main
