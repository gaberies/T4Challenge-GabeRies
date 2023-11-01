import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, welcome to reviewers to the T4 Coding Challenge! </h1>
        <p>Select the login button on the top to get started.</p>
        
        <p>Once you've logged in and made your account select the Set User Type option in order to choose to be an Admin or a Client user.</p>
       
        <p>Thank you for the opportunity!</p>
      </div>
    );
  }
}
