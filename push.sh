#!/bin/bash

git add .
echo "Comment:"
read comment

git commit -m "$comment"

git push origin income
