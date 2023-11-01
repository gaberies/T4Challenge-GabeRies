import React, { useState, useEffect } from 'react';

const AdminFormSubmissionsPage = () => {
    const [formSubmissions, setFormSubmissions] = useState([]);
    const [loading, setLoading] = useState(true);

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
            } finally {
                setLoading(false); // Set loading to false after fetching
            }
        };

        fetchFormSubmissions();
    }, []);

    return (
        <div>
            <h1>Admin Form Submissions Page</h1>
            {loading ? (
                <p>Loading...</p>
            ) : (
                formSubmissions.map((submission) => (
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
                        <p>
                            <strong>Dynamic Fields:</strong>
                            {submission.dynamicFields && submission.dynamicFields.map((field) => (
                                <div key={field.id}>
                                    <p>
                                        <strong>{field.fieldName}:</strong> {field.fieldValue}
                                    </p>
                                </div>
                            ))}
                        </p>
                    </div>
                ))
            )}
        </div>
    );
};

export default AdminFormSubmissionsPage;
