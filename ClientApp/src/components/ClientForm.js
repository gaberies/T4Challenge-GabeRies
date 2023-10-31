import React, { useState, useEffect } from 'react';


const ClientForm = () => {
    const [formData, setFormData] = useState({});
    const [fieldDefinitions, setFieldDefinitions] = useState([]);

    useEffect(() => {
        const fetchFieldDefinitions = async () => {
            try {
                const response = await fetch('/api/FieldDefinitions');
                if (response.ok) {
                    const data = await response.json();
                    setFieldDefinitions(data);
                } else {
                    console.error('Failed to fetch field definitions');
                }
            } catch (error) {
                console.error('Error fetching field definitions:', error);
            }
        };

        fetchFieldDefinitions();
    }, []);

    const handleChange = (e, fieldName) => {
        e.persist();

        setFormData((prevData) => ({
            ...prevData,
            [fieldName]: e.target.value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const formDataToSend = {
                ...formData,
                DynamicFields: fieldDefinitions.map((field) => ({
                    FieldName: field.name,
                    FieldValue: formData[field.name] || '',
                })),
            };

            console.log('JSON to send:', JSON.stringify(formDataToSend)); // Log the JSON string

            const response = await fetch('/api/FormSubmissions', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formDataToSend),
            });

            console.log('Response status:', response.status);
            console.log('Response data:', await response.json());

            if (response.ok) {
                console.log('Form submitted successfully!');
            } else {
                console.error('Failed to submit form:', response.statusText);
            }
        }   catch (error) {
                console.error('Error submitting form:', error);
                console.error('Error details:', await error.json()); // Log the error details
        }
    };


    return (
        <div>
            <form onSubmit={handleSubmit}>
                {fieldDefinitions.map((field) => (
                    <div key={field.id}>
                        <label>
                            {field.name}:
                            {field.type === 'string' && (
                                <input
                                    type="text"
                                    name={field.name}
                                    value={formData[field.name] || ''}
                                    onChange={(e) => handleChange(e, field.name)}
                                />
                            )}
                            {field.type === 'int' && (
                                <input
                                    type="number"
                                    name={field.name}
                                    value={formData[field.name] || ''}
                                    onChange={(e) => handleChange(e, field.name)}
                                />
                            )}
                            {field.type === 'bool' && (
                                <input
                                    type="checkbox"
                                    name={field.name}
                                    checked={formData[field.name] || false}
                                    onChange={(e) => handleChange(e, field.name)}
                                />
                            )}
                            {field.type === 'date' && (
                                <input
                                    type="date"
                                    name={field.name}
                                    value={formData[field.name] || ''}
                                    onChange={(e) => handleChange(e, field.name)}
                                />
                            )}
                        </label>
                        <br />
                    </div>
                ))}
                <button type="submit">Submit</button>
            </form>
        </div>
    );
};

export default ClientForm;
