import useAuth from "@/Hooks/useAuth";
import { Navigate, useLocation } from "react-router-dom";


/**
  * Renders the provided children if the user is authenticated, otherwise redirects to the user credentials page.
  *
  * @param {Object} props - The component props.
  * @param {JSX.Element} props.children - The children to render if the user is authenticated.
  * @return {JSX.Element} The rendered children or a redirect to the user credentials page.
  */

function RequireAuth({ children }: { children: JSX.Element }) {
    const auth = useAuth();
    const location = useLocation();

    if (!auth.userId) {
        return <Navigate to="/userCredentials" state={{ from: location }} replace/>;
    }
    return children;
}

export default RequireAuth;