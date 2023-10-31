import React, { useState, useEffect } from 'react';

const AdminFieldDefinitionsPage = () => {
    const [fieldDefinitions, setFieldDefinitions] = useState([]);
    const [newField, setNewField] = useState({ name: '', type: '' });
    const [editField, setEditField] = useState(null);

    useEffect(() => {
        // Fetch field definitions from the API and update state
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
    }, []); // Run once on component mount

    const addFieldDefinition = async () => {
        try {
            const response = await fetch('/api/FieldDefinitions', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newField),
            });

            if (response.ok) {
                const createdFieldDefinition = await response.json();
                setFieldDefinitions([...fieldDefinitions, createdFieldDefinition]);
                setNewField({ name: '', type: '' }); // Clear the new field input
            } else {
                console.error('Failed to add field definition:', response.statusText);
            }
        } catch (error) {
            console.error('Error adding field definition:', error);
        }
    };

    const editFieldDefinition = async () => {
        if (editField) {
            try {
                const response = await fetch(`/api/FieldDefinitions/${editField.id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(editField),
                });

                if (response.ok) {
                    const responseBody = await response.json();
                    console.log('Response body:', responseBody); // Add this line for logging
                    const updatedFieldDefinition = responseBody;
                    setFieldDefinitions((prevDefinitions) =>
                        prevDefinitions.map((field) => (field.id === updatedFieldDefinition.id ? updatedFieldDefinition : field))
                    );
                    setEditField(null); // Clear the edit field
                } else {
                    console.error('Failed to edit field definition:', response.statusText);
                }
            } catch (error) {
                console.error('Error editing field definition:', error);
            }
        }
    };

    const deleteFieldDefinition = async (id) => {
        try {
            const response = await fetch(`/api/FieldDefinitions/${id}`, {
                method: 'DELETE',
            });

            if (response.ok) {
                setFieldDefinitions((prevDefinitions) => prevDefinitions.filter((field) => field.id !== id));
            } else {
                console.error('Failed to delete field definition:', response.statusText);
            }
        } catch (error) {
            console.error('Error deleting field definition:', error);
        }
    };

    const handleTypeChange = (e) => {
        setNewField({ ...newField, type: e.target.value });
    };

    const startEditing = (field) => {
        setEditField({ ...field });
    };

    const cancelEditing = () => {
        setEditField(null);
    };

    return (
        <div>
            <h1>Admin Field Definitions Page</h1>
            <div>
                <h2>Add New Field</h2>
                <label>
                    Name:
                    <input
                        type="text"
                        value={newField.name}
                        onChange={(e) => setNewField({ ...newField, name: e.target.value })}
                    />
                </label>
                <label>
                    Type:
                    <select value={newField.type} onChange={handleTypeChange}>
                        <option value="string">String</option>
                        <option value="int">Int</option>
                        <option value="bool">Bool</option>
                        <option value="date">Date</option>
                    </select>
                </label>
                <button onClick={addFieldDefinition}>Add Field</button>
            </div>
            <div>
                <h2>Existing Fields</h2>
                <ul>
                    {fieldDefinitions.map((field) => (
                        <li key={field.id}>
                            {editField && editField.id === field.id ? (
                                <>
                                    <label>
                                        Name:
                                        <input
                                            type="text"
                                            value={editField.name}
                                            onChange={(e) => setEditField({ ...editField, name: e.target.value })}
                                        />
                                    </label>
                                    <label>
                                        Type:
                                        <select value={editField.type} onChange={(e) => setEditField({ ...editField, type: e.target.value })}>
                                            <option value="string">String</option>
                                            <option value="int">Int</option>
                                            <option value="bool">Bool</option>
                                            <option value="date">Date</option>
                                        </select>
                                    </label>
                                    <button onClick={editFieldDefinition}>Save</button>
                                    <button onClick={cancelEditing}>Cancel</button>
                                </>
                            ) : (
                                <>
                                    {field.name} - {field.type}
                                    <button onClick={() => startEditing(field)}>Edit</button>
                                    <button onClick={() => deleteFieldDefinition(field.id)}>Delete</button>
                                </>
                            )}
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default AdminFieldDefinitionsPage;
