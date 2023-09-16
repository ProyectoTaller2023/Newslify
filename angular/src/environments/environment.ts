import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Newslify',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44345/',
    redirectUri: baseUrl,
    clientId: 'Newslify_App',
    responseType: 'code',
    scope: 'offline_access Newslify',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44345',
      rootNamespace: 'Newslify',
    },
  },
} as Environment;
