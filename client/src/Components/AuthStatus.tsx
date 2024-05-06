import useAuth from "@/Hooks/useAuth";
import { useNavigate } from "react-router-dom";

//TODO THIS SHOULD BE REFACTORED TO THE INITIAL WELCOME PAGE
/**
 * Renders the authentication status component.
 *
 * @return {JSX.Element} The rendered authentication status component.
 */
function AuthStatus() {
    const auth = useAuth();
    const navigate = useNavigate();

    if (!auth?.userId) {
        return <p>You are not logged in.</p>
    }

    return (
        <p>
            Welcome!
            <button
                onClick={() => {
                    auth.signOut();
                    navigate('/');
                }}
            >
                Sign Out
            </button>
        </p>
    )
}

export default AuthStatus