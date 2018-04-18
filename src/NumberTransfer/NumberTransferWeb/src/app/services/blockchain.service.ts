import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { ExecuteResponse, QueryResponse } from '../models/responses';

@Injectable()
export class BlockchainService {
  public readonly party$: Observable<string>;
  private readonly partySubject = new Subject<string>();
  private readonly baseUrl = 'http://localhost:5000/api';

  constructor(private readonly http: HttpClient) {
    this.party$ = this.partySubject;
  }

  private _party: string;

  public get party(): string {
    return this._party;
  }

  public set party(value: string) {
    this._party = value;
    this.partySubject.next(value);
  }

  createNumber(owner: string, phoneNumber: string): Observable<ExecuteResponse> {
    return this.executeTransaction('CreateNumber', { o: owner, pn: phoneNumber });
  }

  requestTransfer(owner: string, phoneNumber: string, newOwner: string): Observable<ExecuteResponse> {
    return this.executeTransaction('RequestTransfer', { co: owner, no: newOwner, pn: phoneNumber });
  }

  confirmTransferRequest(phoneNumber: string, newOwner: string): Observable<ExecuteResponse> {
    return this.executeTransaction('ConfirmTransferRequest', { no: newOwner, pn: phoneNumber });
  }

  denyTransferRequest(phoneNumber: string, newOwner: string): Observable<ExecuteResponse> {
    return this.executeTransaction('DenyTransferRequest', { no: newOwner, pn: phoneNumber });
  }

  query(command: string, data: string): Observable<QueryResponse> {
    return this.http.post<QueryResponse>(`${this.baseUrl}/command/query`, { c: command, d: data }, { headers: new HttpHeaders().set('X-Party', this.party) });
  }

  private executeTransaction(command: string, payload: any): Observable<ExecuteResponse> {
    return this.http.post<ExecuteResponse>(`${this.baseUrl}/command/${command}`, payload, { headers: new HttpHeaders().set('X-Party', this.party) });
  }
}
