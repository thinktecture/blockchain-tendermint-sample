import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ExecuteResponse } from '../../models/responses';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-create-number',
  templateUrl: './createNumber.component.html',
})
export class CreateNumberComponent {
  owner: string;
  phoneNumber: string;

  httpResult$: Observable<ExecuteResponse>;

  constructor(private readonly blockchainService: BlockchainService) {
  }

  createNumber() {
    this.httpResult$ = this.blockchainService.createNumber(this.owner, this.phoneNumber);
  }
}
