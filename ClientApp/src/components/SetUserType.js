import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class SetUserType extends Component {
    state = {
        isAdmin: false,
        isClient: false,
        redirectTo: null,
    };

    setAdmin = () => {
        this.setState({ isAdmin: true, isClient: false, redirectTo: '/admin' });
    };

    setClient = () => {
        this.setState({ isAdmin: false, isClient: true, redirectTo: '/client' });
    };

    render() {
        const { redirectTo } = this.state;

        if (redirectTo) {
            return <Redirect to={redirectTo} />;
        }

        return (
            <div>
                <h1>Set User Type</h1>
                <p>Please select if you would like your user to be an Admin or a Client!</p>

                <button className="btn btn-primary" onClick={this.setAdmin}>
                    Admin
                </button>
                <p></p>
                <button className="btn btn-primary" onClick={this.setClient}>
                    Client
                </button>
            </div>
        );
    }
}

export default SetUserType;
