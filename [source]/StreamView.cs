using System;

// http://www.pixvillage.com/blogs/devblog/archive/2005/03/08/151.aspx

namespace System.IO
{
  public class StreamView : Stream 
  {
    private Stream baseStream;
    private long offset;
    private long length;
    
    public StreamView(Stream baseStream,long offset,long length) 
    {
      this.baseStream = baseStream;
      this.offset = offset;
      this.length = length;
      baseStream.Position = offset;
    }
    
    public override bool CanRead 
    {
      get { return baseStream.CanRead; }
    }
    
    public override bool CanWrite 
    {
      get { return baseStream.CanWrite; }
    }
    
    public override bool CanSeek 
    {
      get { return baseStream.CanSeek; }
    }
    
    public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) 
    {
      return baseStream.BeginRead (buffer, offset, count, callback, state);
    }
    
    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) 
    {
      return baseStream.BeginWrite (buffer, offset,
        count, callback, state);
    }
    
    public override void Close() 
    {
      baseStream.Close ();
    }
    
    
    public override int EndRead(IAsyncResult asyncResult) 
    {
      return baseStream.EndRead (asyncResult);
    }
    
    public override void EndWrite(IAsyncResult asyncResult) 
    {
      baseStream.EndWrite (asyncResult);
    }
    
    public override void Flush() 
    {
      baseStream.Flush();
    }
    
    public override long Length 
    {
      get { return length; }
    }
    
    public override long Position 
    {
      get { return baseStream.Position - offset; }
      set { baseStream.Position = value + offset; }
    }
    
    public override int Read(byte[] buffer, int offset, int count) 
    {
      return baseStream.Read(buffer,offset,count);
    }
    
    public override int ReadByte() 
    {
      return baseStream.ReadByte ();
    }
    
    public override long Seek (long offset, SeekOrigin origin) 
    {
      switch(origin) 
      {
        case SeekOrigin.Begin: return baseStream.Seek(offset + this.offset,origin) - this.offset;
        case SeekOrigin.Current: return baseStream.Seek(offset,origin) - this.offset;
        case SeekOrigin.End: return baseStream.Seek(this.offset + length - offset, SeekOrigin.Begin) - this.offset;
      }
      return 0;
    }
    
    public override void SetLength (long value) 
    {
      throw new NotSupportedException();
    }
    
    public override void Write(byte[] buffer, int offset, int count) 
    {
      baseStream.Write(buffer,offset,count);
    }
    
    public override void WriteByte(byte value) 
    {
      baseStream.WriteByte(value);
    }
  }
}
