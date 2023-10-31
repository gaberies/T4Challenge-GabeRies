import React, { useState } from 'react';

const ClientForm = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
    });

    const [submitted, setSubmitted] = useState(false);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Handle form submission (e.g., send data to the server)
        console.log('Form submitted:', formData);

        // Set the submitted state to true
        setSubmitted(true);
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
