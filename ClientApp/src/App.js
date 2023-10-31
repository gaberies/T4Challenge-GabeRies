import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { SetUserType } from './components/SetUserType';
import AdminNavigationPage from './components/AdminNavigationPage';
import ClientForm from './components/ClientForm';
import AdminFieldDefinitionsPage from './components/AdminFieldDefinitionsPage';
import AdminFormSubmissionsPage from './components/AdminFormSubmissionsPage';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
 

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <AuthorizeRoute path='/SetUserType' component={SetUserType} />
                <Route path='/client' component={ClientForm} />
                <Route path='/client-Form' component={ClientForm} />
                <Route exact path='/admin' component={AdminNavigationPage} />
                <Route path='/admin/manage-field-definitions' component={AdminFieldDefinitionsPage} />
                <Route path='/admin/review-form-submissions' component={AdminFormSubmissionsPage} />
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            </Layout>
        );
    }
  }

