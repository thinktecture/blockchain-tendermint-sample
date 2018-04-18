import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ExecuteResponse } from '../../models/responses';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-query',
  templateUrl: './query.component.html',
})
export class QueryComponent {
  command: string;
  data: string;

  httpResult$: Observable<ExecuteResponse>;

  constructor(private readonly blockchainService: BlockchainService) {
  }

  query() {
    this.httpResult$ = this.blockchainService.query(this.command, this.data);
  }

  dumpRepository() {
    this.command = 'dump-repository';
    this.data = '';
  }

  openTransfers() {
    this.command = 'open-transfers';
    this.data = '';
  }
}
