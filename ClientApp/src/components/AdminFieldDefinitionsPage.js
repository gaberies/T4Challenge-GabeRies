
import React, { useState } from 'react';

const AdminFieldDefinitionsPage = () => {
    const [fieldDefinitions, setFieldDefinitions] = useState([
        { id: 1, name: 'FirstName', type: 'string' },
        { id: 2, name: 'Age', type: 'int' },
        
    ]);

 
    const addFieldDefinition = (newFieldDefinition) => {
        setFieldDefinitions([...fieldDefinitions, newFieldDefinition]);
    };

   
    const editFieldDefinition = (id, updatedFieldDefinition) => {
        setFieldDefinitions(fieldDefinitions.map((field) => (field.id === id ? updatedFieldDefinition : field)));
    };

    const deleteFieldDefinition = (id) => {
        setFieldDefinitions(fieldDefinitions.filter((field) => field.id !== id));
    };

    return (
        <div>
            <h1>Admin Field Definitions Page</h1>
        </div>
    );
};

export default AdminFieldDefinitionsPage;
