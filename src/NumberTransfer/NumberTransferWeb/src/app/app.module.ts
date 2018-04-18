import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app.routing';
import { CardComponent } from './components/card/card.component';
import { ConfirmTransferRequestComponent } from './components/confirmTransferRequest/confirmTransferRequest.component';
import { CreateNumberComponent } from './components/createNumber/createNumber.component';
import { DenyTransferRequestComponent } from './components/denyTransferRequest/denyTransferRequest.component';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { PartyComponent } from './components/party/party.component';
import { PrettyJsonComponent } from './components/prettyJson/prettyJson.component';
import { QueryComponent } from './components/query/query.component';
import { RequestTransferComponent } from './components/requestTransfer/requestTransfer.component';
import { RootComponent } from './components/root/root.component';
import { BlockchainService } from './services/blockchain.service';

@NgModule({
  declarations: [
    RootComponent,
    HomeComponent,
    HeaderComponent,
    PartyComponent,
    CreateNumberComponent,
    PrettyJsonComponent,
    ConfirmTransferRequestComponent,
    DenyTransferRequestComponent,
    RequestTransferComponent,
    CardComponent,
    QueryComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [BlockchainService],
  bootstrap: [RootComponent],
})
export class AppModule {
}
