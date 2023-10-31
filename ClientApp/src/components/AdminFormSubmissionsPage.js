
import React, { useState } from 'react';

const AdminFormSubmissionsPage = () => {
    const [formSubmissions, setFormSubmissions] = useState([
        { id: 1, data: { FirstName: 'John', Age: 30 } },
        { id: 2, data: { FirstName: 'Jane', Age: 25 } },
    ]);

    return (
        <div>
            <h1>Admin Form Submissions Page</h1>
            
        </div>
    );
};

export default AdminFormSubmissionsPage;
