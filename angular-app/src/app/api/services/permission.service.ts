/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { Permission } from '../models/permission';

@Injectable({
  providedIn: 'root',
})
export class PermissionService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation permissionGet
   */
  static readonly PermissionGetPath = '/Permission';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `permissionGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  permissionGet$Response(params?: {
    role?: string;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<Permission>>> {

    const rb = new RequestBuilder(this.rootUrl, PermissionService.PermissionGetPath, 'get');
    if (params) {
      rb.query('role', params.role, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Permission>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `permissionGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  permissionGet(params?: {
    role?: string;
  },
  context?: HttpContext

): Observable<Array<Permission>> {

    return this.permissionGet$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<Permission>>) => r.body as Array<Permission>)
    );
  }

}
