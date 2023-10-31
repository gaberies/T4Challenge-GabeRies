import React, { useState } from 'react';

const ClientForm = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
    });

    const [submitted, setSubmitted] = useState(false);

    const handleChange = (e) => {
        e.persist();
        setFormData((prevData) => ({
            ...prevData,
            [e.target.name]: e.target.value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch('/api/FormSubmissions', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    firstName: formData.firstName,
                    lastName: formData.lastName,
                }),
            });

            console.log('Request data:', JSON.stringify({
                firstName: formData.firstName,
                lastName: formData.lastName,
            }));

            console.log('Response status:', response.status);

            if (response.ok) {
                console.log('Form submitted successfully!');
                setSubmitted(true);
            } else {
                const errorText = await response.text();
                console.error('Failed to submit form:', errorText);
            }
        } catch (error) {
            console.error('Error submitting form:', error);
        }
    };

    return (
        <div>
            {submitted ? (
                <p>Form Submitted!</p>
            ) : (
                <form onSubmit={handleSubmit}>
                    <label>
                        First Name:
                        <input type="text" name="firstName" value={formData.firstName} onChange={handleChange} />
                    </label>
                    <br />
                    <label>
                        Last Name:
                        <input type="text" name="lastName" value={formData.lastName} onChange={handleChange} />
                    </label>
                    <br />
                    <button type="submit">Submit</button>
                </form>
            )}
        </div>
    );
};

export default ClientForm;
