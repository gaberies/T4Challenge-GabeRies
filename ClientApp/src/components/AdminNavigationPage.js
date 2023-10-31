import React from 'react';
import { Link } from 'react-router-dom';

const AdminNavigationPage = () => {
    return (
        <div>
            <h1>Admin Navigation Page</h1>
            <Link to="/admin/manage-field-definitions">
                <button>Manage Field Definitions</button>
            </Link>
            <Link to="/admin/review-form-submissions">
                <button>Review Form Submissions</button>
            </Link>
        </div>
    );
};

export default AdminNavigationPage;
