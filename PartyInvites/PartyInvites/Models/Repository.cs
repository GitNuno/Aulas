﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    // NEVER DO THIS !!!
    // This is only for demonstration/academic purposes
    public class Repository {
        private static List<GuestResponse> responses = new List<GuestResponse>();

        // public static List<GuestResponse> Responses // ORIGINAL
        public static IEnumerable<GuestResponse> Responses // IEnumerable permite correr elementos mas nao inserir ???
        {
            get {
                return responses; // devolve lista
            }
        }

        public static void AddResponse(GuestResponse response) {
            responses.Add(response); // adiciono respostas á lista listResponses
        }
    }
}
