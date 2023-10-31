import React, { useState, useEffect } from 'react';

const AdminFormSubmissionsPage = () => {
    const [formSubmissions, setFormSubmissions] = useState([]);

    useEffect(() => {
        const fetchFormSubmissions = async () => {
            try {
                const response = await fetch('/api/FormSubmissions');
                console.log('Response status:', response.status);
                const data = await response.json();
                console.log('Form submissions:', data);
                if (response.ok) {
                    setFormSubmissions(data);
                } else {
                    console.error('Failed to fetch form submissions');
                }
            } catch (error) {
                console.error('Error fetching form submissions:', error);
            }
        };

        fetchFormSubmissions();
    }, []);

    return (
        <div>
            <h1>Admin Form Submissions Page</h1>
            {formSubmissions.map((submission) => (
                <div key={submission.id}>
                    <h3>Submission #{submission.id}</h3>
                    <p>
                        <strong>First Name:</strong> {submission.firstName}
                    </p>
                    <p>
                        <strong>Last Name:</strong> {submission.lastName}
                    </p>
                    <p>
                        <strong>Submission Date:</strong> {submission.submissionDate}
                    </p>
                </div>
            ))}
        </div>
    );
};

export default AdminFormSubmissionsPage;
