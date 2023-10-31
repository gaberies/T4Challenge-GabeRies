import React, { useState, useEffect } from 'react';

const ClientForm = () => {
    const [formData, setFormData] = useState({
        firstName: localStorage.getItem('firstName') || '',
        lastName: localStorage.getItem('lastName') || '',
    });

    const [submitted, setSubmitted] = useState(false);

    useEffect(() => {
        localStorage.setItem('firstName', formData.firstName);
        localStorage.setItem('lastName', formData.lastName);
    }, [formData]);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('Form submitted:', formData);
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
