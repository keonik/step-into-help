#!/bin/bash

# Function to kill all child processes
cleanup() {
    echo "Stopping all processes..."
    kill $(jobs -p)
    exit 0
}

# Set up trap to call cleanup function when script receives SIGINT
trap cleanup SIGINT

dotnet build
# Start the .NET backend
dotnet run &

cd client
pnpm install
# Start the client app
pnpm dev &

# Wait for all background processes to finish
wait