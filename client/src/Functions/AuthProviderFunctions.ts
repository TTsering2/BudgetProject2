const AuthProviderFunction = {
  userId: undefined,
  isAuthenticated: false,
  async signIn(username: string, password: string): Promise<void> {
    try {
      //TODO: FIND ENDPOINT
      const response = await fetch(
        `http://localhost:5112/api/user/login?username=${encodeURIComponent(username)}&password=${encodeURIComponent(password)}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ username, password }),
        },
      );

      if (!response.ok) {
        throw new Error("Failed to sign in");
      }

      const data = await response.json();
      if (data.userId) {
        this.userId = data.userId;
        this.isAuthenticated = true; // Update authentication state
      } else {
        throw new Error(data.errorMessage || "Authentication failed");
      }
    } catch (error) {
      console.error(error);
      throw error;
    }
  },
  async signOut(): Promise<void> {
    await new Promise((resolve) => setTimeout(resolve, 500)); // Simulate network latency
    this.userId = undefined;
    this.isAuthenticated = false; // Update authentication state
  },
};

export { AuthProviderFunction };
