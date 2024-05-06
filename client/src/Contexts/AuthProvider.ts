interface AuthenticationProvider {
    isAuthenticated: boolean;
    userId: null | number;
    signIn(userId: number): Promise<void>;
    signOut(): Promise<void>;
}

export const AuthProvider: AuthenticationProvider = {
    isAuthenticated: false,
    userId: null,
    async signIn(userId: number) {
        await new Promise((r)=>setTimeout(r,500));
        AuthProvider.isAuthenticated = true;
        AuthProvider.userId = userId;
    },
    async signOut() {
        await new Promise((r)=>setTimeout(r,500));
        AuthProvider.isAuthenticated = false;
        AuthProvider.userId = null;
    },
};