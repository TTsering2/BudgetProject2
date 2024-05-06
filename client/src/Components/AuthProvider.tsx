import React, { useState, useCallback } from "react";
import AuthContext from "../Hooks/AuthContext";
import { AuthProviderFunction } from "../Functions/AuthProviderFunctions";

/**
 * Creates an authentication provider component that wraps the given children components.
 *
 * @param {Object} props - The props object.
 * @param {React.ReactNode} props.children - The children components to be wrapped by the authentication provider.
 * @return {JSX.Element} The authentication provider component.
 */
function AuthProvider({ children }: { children: React.ReactNode }): JSX.Element {
    const [userId, setUserId] = useState<number | undefined>(undefined);
    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);

    // Define the signIn method
    const signIn = useCallback(async (username: string, password: string) => {
        try {
            await AuthProviderFunction.signIn(username, password);
            setUserId(AuthProviderFunction.userId);
            setIsAuthenticated(AuthProviderFunction.isAuthenticated);
        } catch (error) {
            console.error(error);
            // Reset authentication state
            setUserId(undefined);
            setIsAuthenticated(false);
            throw error;
        }
    }, []);

    // Define the signOut method
    const signOut = useCallback(async () => {
        try {
            await AuthProviderFunction.signOut();
            setUserId(undefined);
            setIsAuthenticated(false);
        } catch (error) {
            console.error(error);
            throw error;
        }
    }, []);

    // Provide the context value
    const value = {
        userId,
        isAuthenticated,
        signIn,
        signOut
    };

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    );
}

export default AuthProvider;
