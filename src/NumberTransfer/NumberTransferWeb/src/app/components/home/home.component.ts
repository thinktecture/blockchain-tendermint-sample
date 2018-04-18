import { Component } from '@angular/core';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(blockchainService: BlockchainService) {
    blockchainService.party = '';
  }
}
