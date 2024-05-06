import React from "react";

interface AuthContextType {
        userId?: number,
        signIn: (username: string, password: string) => Promise<void>;
        signOut(): Promise<void>;
}

let AuthContext = React.createContext<AuthContextType | null>(null);

export default AuthContext;