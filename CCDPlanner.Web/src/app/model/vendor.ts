import { Company } from './company';

export interface Vendor {
  id: string;
  name: string;

  exchangeUsername: string;
  exchangePassword: string;
  exchangeUrl: string;
  google_Api_ClientId: string;
  google_Api_ClientSecret: string;
  google_Api_Email: string;
  google_Api_RefreshToken: string;
  google_App_Name: string;


  //isGoogleSyncEnabled: boolean;
  //isExchangeSyncEnabled: boolean;
  syncType: number;

  isEnabled: boolean;


  companies: Company[];
}
