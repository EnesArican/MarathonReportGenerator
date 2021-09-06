import Vue from 'vue';
import { JsonServiceClient, GetNavItemsResponse, UserAttributes, IAuthSession } from '@servicestack/client';

declare let global: any; // populated from package.json/jest

export const client = new JsonServiceClient(global.testURL || '/');

export {
    errorResponse, errorResponseExcept,
    splitOnFirst, toPascalCase,
    queryString,
} from '@servicestack/client';




export enum Roles {
  Admin = 'Admin',
}

// Shared state between all Components
interface State {
  nav: GetNavItemsResponse;
  userSession: IAuthSession | null;
  userAttributes?: string[];
  roles?: string[];
  permissions?: string[];
}






